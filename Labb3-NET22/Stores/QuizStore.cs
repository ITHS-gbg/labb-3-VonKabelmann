using Labb3_NET22.DataModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Labb3_NET22.Stores;

public class QuizStore // byta namn till QuizManager och flytta till managers?
{
    public Quiz CurrentQuiz { get; set; }

    public int QuestionsAmount { get; set; }

    public bool CheckIfFileExists(string fileName)
    {
        var pathToFile = Path.Combine(Constants.QuizlyFolderPath, fileName);
        return File.Exists(pathToFile);
    }
    public void CreateQuizlyFolder()
    {
        Directory.CreateDirectory(Constants.QuizlyFolderPath);
    }
    public async Task SaveQuizToFileAsync()
    {
        await Task.Run(CreateQuizlyFolder);
        var json = JsonSerializer.Serialize(CurrentQuiz, new JsonSerializerOptions() { WriteIndented = true });
        var filePath = Path.Combine(Constants.QuizlyFolderPath, $"{CurrentQuiz.Title}.json");
        await using var sw = new StreamWriter(filePath);
        await sw.WriteLineAsync(json);
        MessageBox.Show("Quiz successfully saved to file.", "Quiz Saved", MessageBoxButton.OK);
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