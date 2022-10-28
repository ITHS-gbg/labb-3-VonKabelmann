using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Text.Json.Nodes;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.Managers;

public class FileManager
{
    private readonly string _folderPath;

    public FileManager()
    {
        _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizly");
    }

    public bool CheckIfFileExists(string fileName)
    {
        var pathToFile = Path.Combine(_folderPath, fileName);
        return File.Exists(pathToFile);
    }
    public void CreateLocalDirectory()
    {
        Directory.CreateDirectory(_folderPath);
    }
    public void SaveQuizToFile(Quiz quiz)
    {
        var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions() { WriteIndented = true });
        var filePath = Path.Combine(_folderPath, $"{quiz.Title}.json");
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(json);
    }
}