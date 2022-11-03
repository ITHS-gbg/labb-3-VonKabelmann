using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class EditQuestionViewModel : ObservableObject
{
    private readonly EditQuestionModel _editQuestionModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    public EditQuestionViewModel(EditQuestionModel editQuestionModel, NavigationStore localNavigationStore, NavigationStore navigationStore, QuizStore quizStore)
    {
        _editQuestionModel = editQuestionModel;
        _localNavigationStore = localNavigationStore;
        _navigationStore = navigationStore;
        _quizStore = quizStore;
    }

    #region Properties

    #region Command Properties

    public ICommand SubmitCommand { get; }

    #endregion

    private int _currentQuestionNum;
    public int CurrentQuestion
    {
        get => _currentQuestionNum;
        set => SetProperty(ref _currentQuestionNum, value);
    }
    public string QuestionStatement
    {
        get => _editQuestionModel.QuestionStatement;
        set { SetProperty(_editQuestionModel.QuestionStatement, value, (v) => _editQuestionModel.QuestionStatement = v); }
    }
    public QuestionCategory SelectedCategory
    {
        get => _editQuestionModel.Category;
        set
        {
            if (_editQuestionModel.Category != value)
            {
                SetProperty(_editQuestionModel.Category, value, (v) => _editQuestionModel.Category = v);
            }
        }
    }
    public string[] QuestionAnswers
    {
        get => _editQuestionModel.QuestionAnswers;
        set { SetProperty(_editQuestionModel.QuestionAnswers, value, (v) => _editQuestionModel.QuestionAnswers = v); }
    }
    public int CorrectAnswer
    {
        get => _editQuestionModel.CorrectAnswer;
        set { SetProperty(_editQuestionModel.CorrectAnswer, value, (v) => _editQuestionModel.CorrectAnswer = v); }
    }
    private bool[] _selectedAnswerArray;
    public bool[] SelectedAnswerArray
    {
        get => _selectedAnswerArray;
        set => SetProperty(ref _selectedAnswerArray, value);
    }

    #endregion

    #region Command Content

    //private void Setup

    #endregion
}