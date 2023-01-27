using Autofac;
using Core.Autofac;
using Flags.Services.FlagsDetector;
using AForge.Video.DirectShow;
using AForge.Video;
using System.ComponentModel;

namespace GUI;

public partial class MainForm : Form
{
    private readonly FlagsDetectorService _flagsService;
    private readonly FilterInfoCollection _cameras;
    private VideoCaptureDevice? VideoDevice;
    private Bitmap? TaggedImage;

    public MainForm()
    {
        using var autofac = WinFormAutofacFactory.CreateScope(UsedModules.List);
        _flagsService = autofac.Resolve<FlagsDetectorService>();
        _cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        InitializeComponent();
    }

    /// <summary>
    /// Dispose camera on window closing
    /// </summary>
    protected override void OnClosing(CancelEventArgs e)
    {
        buttonStop_Click(null, null);
        base.OnClosing(e);
    }

    /// <summary>
    /// Load available cameras on window opening
    /// </summary>
    private void MainForm_Load(object sender, EventArgs e)
    {
        foreach (FilterInfo filter in _cameras) comboBoxCamera.Items.Add(filter.Name);
        comboBoxCamera.SelectedIndex = 0;
        comboBoxCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        labelState.Text = "Stopped";

        // Aktualnie predykcja trwa 1s. Oto co ChatGPT doradzi� aby to przy�pieszy�:
        // 1. Pobierz i zainstaluj odpowiedni� wersj� NVIDIA TensorRT na swoim komputerze.
        // 2. W swoim projekcie C# ML.NET doda� odwo�anie do biblioteki NVIDIA TensorRT.
        // 3. Zmieni� kod tworz�cy silnik predykcji na kod tworz�cy silnik TensorRT. Przyk�ad kodu:
        //
        //    var mlContext = new MLContext();
        //    var mlModel = mlContext.Model.Load(MyModelZipPath, out var _);
        //    var engine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel, device: TensorRTDevice.Gpu);
        //
        // 4. Nale�y pami�ta�, �e TensorRT wymaga, aby wszystkie dane wej�ciowe i wyj�ciowe by�y typu float, wi�c je�li twoje dane wej�ciowe lub wyj�ciowe s� innego typu, b�dziesz musia� je zmieni�.
    }

    /// <summary>
    /// Next button click event -> Run Analyze or Start function
    /// </summary>
    private void buttonNext_Click(object sender, EventArgs e)
    {
        if (buttonNext.Text == "Analyze")
            Analyze();
        else
            Start();
    }

    /// <summary>
    /// Stop button click event -> dispose camera
    /// </summary>
    private void buttonStop_Click(object? sender, EventArgs? e)
    {
        VideoDevice?.SignalToStop();
        VideoDevice?.WaitForStop();
        VideoDevice?.Stop();
        pictureBoxCamera.Image = null;
        VideoDevice = null;
        buttonNext.Text = "Start";
        labelState.Text = "Stopped";
        buttonStop.Enabled = false;
    }

    /// <summary>
    /// Replace PictureBox image on webcam frame
    /// </summary>
    private void VideoCaptureDevice_NewFrame(object? sender, NewFrameEventArgs eventArgs)
    {
        pictureBoxCamera.Image = (Bitmap)eventArgs.Frame.Clone();
    }

    /// <summary>
    /// Start selected webcam
    /// </summary>
    private void Start()
    {
        if (VideoDevice != null && VideoDevice.IsRunning)
        {
            return;
        }

        VideoDevice = new VideoCaptureDevice(_cameras[comboBoxCamera.SelectedIndex].MonikerString);
        VideoDevice.NewFrame += VideoCaptureDevice_NewFrame;
        VideoDevice.Start();
        buttonNext.Text = "Analyze";
        labelState.Text = "Started";
        buttonStop.Enabled = true;
    }

    /// <summary>
    /// Analyze current webcam frame and draw results
    /// </summary>
    private void Analyze()
    {
        buttonNext.Enabled = false;
        labelState.Text = "Analyzing...";
        if (TaggedImage != null)
        {
            TaggedImage.Dispose();
            TaggedImage = null;
        }

        using var bmp = (Image)pictureBoxCamera.Image.Clone();
        buttonStop_Click(null, null);
        TaggedImage = _flagsService.Detect(bmp);
        pictureBoxCamera.Image = TaggedImage;
        labelState.Text = "Analysis result";
        buttonNext.Text = "Start";
        buttonNext.Enabled = true;
    }
}