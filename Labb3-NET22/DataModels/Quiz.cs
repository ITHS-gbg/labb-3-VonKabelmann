using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3_NET22.DataModels;   

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;

    public Quiz(string title)
    {
        _questions = new List<Question>();
        _title = title;
    }

    public Question GetRandomQuestion()
    {
        throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void AddQuestion(string statement, int correctAnswer, QuestionCategory category, params string[] answers)
    {
        List<Question> toList = _questions.ToList();
        toList.Add(new Question(statement, answers, correctAnswer, category));
        _questions = toList;
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }
}