using Labb3_NET22.DataModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Labb3_NET22.Stores;

public class QuizStore
{
    public Quiz CurrentQuiz { get; set; }

    public bool CheckIfFileExists(string fileName)
    {
        var pathToFile = Path.Combine(Constants.QuizlyFolderPath, fileName);
        return File.Exists(pathToFile);
    }
    public void CreateQuizlyFolder()
    {
        Directory.CreateDirectory(Constants.QuizlyFolderPath);
    }
    public void SaveQuizToFile(Quiz quiz)
    {
        CreateQuizlyFolder();
        var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions() { WriteIndented = true });
        var filePath = Path.Combine(Constants.QuizlyFolderPath, $"{quiz.Title}.json");
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(json);
    }
    public Quiz? GetQuizFromFile(string filePath)
    {
        var text = string.Empty;
        string? line = string.Empty;
        using StreamReader sr = new StreamReader(filePath);
        while ((line = sr.ReadLine()) != null)
        {
            text += line;
        }

        return JsonSerializer.Deserialize<Quiz>(text);
    }
    public IEnumerable<Quiz> GetAllQuizzesFromFolder()
    {
        CreateQuizlyFolder();
        var filePaths = Directory.GetFiles(Constants.QuizlyFolderPath);
        return filePaths.Select(filePath => GetQuizFromFile(filePath)).ToList();
    }
}