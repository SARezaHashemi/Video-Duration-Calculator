# Video Duration Calculator 🎥⏱

A simple .NET command-line tool that scans a directory and calculates the total duration of all video files.

## Features
- ✅ Supports MP4
- ⚡ Supports recursive search in folders 
- 📝 Simple console output

## Requirements
- .NET 8.0 or higher

## Installation
1. Clone the repository:
```bash
git clone https://github.com/SARezaHashemi/Video-Duration-Calculator.git
```
2. Build the project
```bash
dotnet build
```
3. Make sure you have ffmpeg cli on your system
## Usage
```bash
dotnet run -- /path/to/folder/ <Options>
```
|Option|Description|Flag|
|:-----:|:--------:|:--:|
|Recursive Search| Search in folder and all sub folders to find video files| -r |


## Note
- This project is developed on arch-linux, and it is tested on Microsoft Windows.
- If you have problem with the code make sure you installed ffmpeg[https://www.ffmpeg.org/] and it works correctly
- If you have installed a ffmpeg build like gyan.dev make sure to add ffmpeg to your Microsoft Windows Path in the Environment Variables.

