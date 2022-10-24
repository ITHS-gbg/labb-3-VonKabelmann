using System.Windows;

namespace Labb3_NET22.DataModels;

public class CreateQuizModel
{
    public string QuizTitle { get; set; }
    public int NumberOfQuestions { get; set; }
    public string QuestionStatement { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    public string Answer3 { get; set; }
    public string Answer4 { get; set; }
    public int CorrectAnswer { get; set; }
    public string TestText { get; set; }

    public string GetTestText()
    {
        return $"QuizTitle: {QuizTitle}, NumberOfQuestions: {NumberOfQuestions}";
    }
    
    
}