using System.Diagnostics;
using System.Collections.Concurrent;

#region INITIALIZATION
string pathInput = @"C:\Users\kirill\Desktop\text.txt";
string pathOutput = @"C:\Users\kirill\Desktop\text2.txt";
string pathOutputParallel = @"C:\Users\kirill\Desktop\text2parallel.txt";
ConcurrentDictionary<string, int> wordsAndTheirCount= new ConcurrentDictionary<string, int>();
Dictionary<string, int> wordsAndCount= new Dictionary<string, int>();
Stopwatch stopwatch = new Stopwatch();
Stopwatch stopwatchParallel = new Stopwatch();
#endregion

#region READ AND SPLIT
string readText = File.ReadAllText(pathInput);
string[] subs = readText.Split(' ', ',', '.', '\t', '\n', '-', '[', ']', '(', ')', ';', '!', '"', '?', ':',
                                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\r', '\0');
#endregion

#region MAIN WORK
stopwatchParallel.Start();
Parallel.ForEach<string>(subs,
    (sub) => 
    {
        if (sub != "" && sub != " " && sub != "\n" && sub != "\r")
        {
            if (!wordsAndTheirCount.ContainsKey(sub.ToLower()))
            {
                wordsAndTheirCount.TryAdd(sub.ToLower(), 1);
            }
            else
            {
                wordsAndTheirCount[sub.ToLower()]++;
            }
        }
    });
stopwatchParallel.Stop();

stopwatch.Start();
foreach (var sub in subs)
{
    Task task = Task.Run(() =>
    {
        if (sub != "" && sub != " " && sub != "\n" && sub != "\r")
        {
            if (!wordsAndCount.ContainsKey(sub.ToLower()))
            {
                wordsAndCount.Add(sub.ToLower(), 1);
            }
            else
            {
                wordsAndCount[sub.ToLower()]++;
            }
        }
    });
    task.Wait();
}
stopwatch.Stop();
#endregion

#region SORT
var sortedDictParallel = wordsAndTheirCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
var sortedDict = wordsAndCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
#endregion

#region FILE CREATION
using (File.Create(pathOutput))
{
    
}

using (File.Create(pathOutputParallel))
{

}
#endregion

#region FILE COMPLITION
foreach (var v in sortedDictParallel)
{
    string result = $"word: {v.Key}\t \t count: {v.Value}" + Environment.NewLine;
    File.AppendAllText(pathOutputParallel, result);
}

foreach (var v in sortedDict)
{
    string result = $"word: {v.Key}\t \t count: {v.Value}" + Environment.NewLine;
    File.AppendAllText(pathOutput, result);
}
#endregion

#region PRINTING
Console.WriteLine($"Time for single programming {stopwatch.ElapsedMilliseconds}");
Console.WriteLine($"Time for parallel programming {stopwatchParallel.ElapsedMilliseconds}");
#endregion