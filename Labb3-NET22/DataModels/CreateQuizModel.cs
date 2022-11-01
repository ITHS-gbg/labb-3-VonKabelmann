using System.Reflection;
using System.Windows;
using Labb3_NET22.Managers;

namespace Labb3_NET22.DataModels;

public class CreateQuizModel
{
    public Quiz NewQuiz { get; set; }
    public string QuestionStatement { get; set; }
    public string[] QuestionAnswers { get; set; }
    public int CorrectAnswer { get; set; }  
    public QuestionCategory Category { get; set; }

    public void AddNewQuestion()
    {
        NewQuiz.AddQuestion(QuestionStatement, CorrectAnswer, Category, QuestionAnswers);
    }

    public void SaveQuiz()
    {
        var fileManager = new FileManager();
        fileManager.SaveQuizToFile(NewQuiz);
    }

    public bool CheckIfQuizExists()
    {
        var fileManager = new FileManager();
        return fileManager.CheckIfFileExists($"{NewQuiz.Title}.json");
    }
}