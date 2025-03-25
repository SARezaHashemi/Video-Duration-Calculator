using System.Diagnostics;


if (args.Length ==0)
{
    Console.WriteLine("Please enter a path to a directory");
    return;
}


bool IsRecursive = args.Any(a => a=="-r");
string path = "";
if(!IsRecursive) path = args[0];
else{
    foreach(string arg in args){
        if(arg != "-r") path = arg;
    }
}
path = Path.GetFullPath(path);

if(!Directory.Exists(path)){
    Console.WriteLine("Please enter a valid path to a directory");
    return;
}
List<string> files = new ();
if(!IsRecursive){
    files = Directory.GetFiles(path,"*.mp4").ToList();
    files = files.Order().ToList();
}
else{
    files = GetFiles(path).Order().ToList();
}

if(files.Count()==0){
    Console.WriteLine("No Video File Found");
    return;
}


TimeSpan spn = TimeSpan.Zero;
foreach(var file in files){
    TimeSpan filespn = GetDuration(file);
    spn += filespn;
    Console.WriteLine($"{file.Split('/')[^1]}: {filespn}");
}

Console.WriteLine($"total Duration: {spn}");




TimeSpan GetDuration(string file)
{
    ProcessStartInfo inf = new(){
        FileName ="ffmpeg",
        Arguments = $"-i \"{file}\"",
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };
    string output;
    using(Process process = Process.Start(inf)){
        using (StreamReader reader = process.StandardError)
            {
                output= reader.ReadToEnd();
            }
    }
    string durline = output.Split('\n')
    .FirstOrDefault(l => l.Contains("Duration"));
    string dur = durline.Split(',')[0].Trim().Split(' ')[1];
    TimeSpan span;
    if(!TimeSpan.TryParse(dur,out span)){
        span = TimeSpan.Zero;
        System.Console.WriteLine($"Error during parsing {file}");
    }
    return span;
}


List<string> GetFiles(string path)
{
    List<string> files =  Directory.GetFiles(path,"*.mp4").ToList();
    foreach(var dir in Directory.GetDirectories(path))
    {
        files.AddRange(GetFiles(dir));
    }
    return files;
}
