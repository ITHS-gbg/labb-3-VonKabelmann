namespace Labb3_NET22.DataModels;

public class EditQuestionModel
{
    public string QuestionStatement { get; set; }
    public string[] QuestionAnswers { get; set; }
    public int CorrectAnswer { get; set; }
    public QuestionCategory Category { get; set; }
}