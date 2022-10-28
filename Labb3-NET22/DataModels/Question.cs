namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }
    public QuestionCategory Category { get; }

    //public <T?> Image
    public Question(string statement, string[] answers, int correctAnswer, QuestionCategory category)
    {
        Statement = statement;
        Answers = answers;
        CorrectAnswer = correctAnswer;
        Category = category;
    }
}