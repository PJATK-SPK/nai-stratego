# Authors: Sandro Sobczynski, Marcel Pankanin

# Flags detection
### Problem & resolution:
```
.NET WinForms program that uses ML.NET to detect three flags: Polish, Ukrainian and Russian using a webcam. 
The problem that this program addresses is the need to accurately identify these flags in real-time video. 
To solve this problem, the program utilizes machine learning algorithms 
to analyze frames from the webcam in order to identify the flags. 
The program is able to accurately detect the flags and display the results in real-time on the user interface.

Each detected flag is drawn on analysis frame. Aditionally the program displays the score and position of the flag.
```

### Video (YouTube):
[![Watch the video](https://img.youtube.com/vi/WpriSTPdPqU/0.jpg)](https://youtu.be/WpriSTPdPqU)

### Flags dataset:
```
To train our model we prepared 100+ photos with Polish, Ukrainian and Russian flags. Photos was later on tagged with usage. 
of VOTT. To increaase accuraccy we tried to include photos where there are different flags, and photos where there are more
than one flags needed to be recognized.
```
[Google drive with dataset](https://drive.google.com/drive/folders/1ZhsT9sr2UM_Znh3MuHO3zD3RltBrlID7?usp=sharing)

### Libraries
- ML.NET
- AForge.Imaging
- Autofac

### How to run
Please install:
- Latest Visual Studio  

Run GUI project

### Authors: 
- Sandro Sobczynski (s20600)
- Marcel Pankanin (s21167)
