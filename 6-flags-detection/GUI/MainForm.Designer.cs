namespace GUI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.comboBoxCamera = new System.Windows.Forms.ComboBox();
        this.labelCamera = new System.Windows.Forms.Label();
        this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
        this.buttonNext = new System.Windows.Forms.Button();
        this.buttonStop = new System.Windows.Forms.Button();
        this.labelState = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
        this.SuspendLayout();
        // 
        // comboBoxCamera
        // 
        this.comboBoxCamera.FormattingEnabled = true;
        this.comboBoxCamera.Location = new System.Drawing.Point(69, 12);
        this.comboBoxCamera.Name = "comboBoxCamera";
        this.comboBoxCamera.Size = new System.Drawing.Size(487, 23);
        this.comboBoxCamera.TabIndex = 0;
        // 
        // labelCamera
        // 
        this.labelCamera.AutoSize = true;
        this.labelCamera.Location = new System.Drawing.Point(12, 15);
        this.labelCamera.Name = "labelCamera";
        this.labelCamera.Size = new System.Drawing.Size(51, 15);
        this.labelCamera.TabIndex = 1;
        this.labelCamera.Text = "Camera:";
        // 
        // pictureBoxCamera
        // 
        this.pictureBoxCamera.Location = new System.Drawing.Point(12, 41);
        this.pictureBoxCamera.Name = "pictureBoxCamera";
        this.pictureBoxCamera.Size = new System.Drawing.Size(544, 345);
        this.pictureBoxCamera.TabIndex = 2;
        this.pictureBoxCamera.TabStop = false;
        // 
        // buttonNext
        // 
        this.buttonNext.Location = new System.Drawing.Point(480, 423);
        this.buttonNext.Name = "buttonNext";
        this.buttonNext.Size = new System.Drawing.Size(75, 23);
        this.buttonNext.TabIndex = 3;
        this.buttonNext.Text = "Start";
        this.buttonNext.UseVisualStyleBackColor = true;
        this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
        // 
        // buttonStop
        // 
        this.buttonStop.Location = new System.Drawing.Point(11, 422);
        this.buttonStop.Name = "buttonStop";
        this.buttonStop.Size = new System.Drawing.Size(75, 23);
        this.buttonStop.TabIndex = 4;
        this.buttonStop.Text = "Stop";
        this.buttonStop.UseVisualStyleBackColor = true;
        this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
        // 
        // labelState
        // 
        this.labelState.AutoSize = true;
        this.labelState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.labelState.Location = new System.Drawing.Point(15, 394);
        this.labelState.MinimumSize = new System.Drawing.Size(538, 20);
        this.labelState.Name = "labelState";
        this.labelState.Size = new System.Drawing.Size(538, 21);
        this.labelState.TabIndex = 6;
        this.labelState.Text = "TEST TEST TEST TEST TEST";
        this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(567, 456);
        this.Controls.Add(this.labelState);
        this.Controls.Add(this.buttonStop);
        this.Controls.Add(this.buttonNext);
        this.Controls.Add(this.pictureBoxCamera);
        this.Controls.Add(this.labelCamera);
        this.Controls.Add(this.comboBoxCamera);
        this.Name = "MainForm";
        this.Text = "Flags detector";
        this.Load += new System.EventHandler(this.MainForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private ComboBox comboBoxCamera;
    private Label labelCamera;
    private PictureBox pictureBoxCamera;
    private Button buttonNext;
    private Button buttonStop;
    private Label labelState;
}
