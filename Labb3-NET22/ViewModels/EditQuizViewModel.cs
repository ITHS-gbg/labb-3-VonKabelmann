using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class EditQuizViewModel : ObservableObject
{
    private readonly EditQuizModel _editQuizModel;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    public EditQuizViewModel(EditQuizModel editQuizModel, NavigationStore localNavigationStore, QuizStore quizStore)
    {
        _editQuizModel = editQuizModel;
        _localNavigationStore = localNavigationStore;
        _quizStore = quizStore;
    }

    #region Properties

    #region Command Properties

    public ICommand CreateCommand { get; }

    #endregion

    private string _quizTitle;
    public string QuizTitle
    {
        get => _quizTitle;
        set => SetProperty(ref _quizTitle, value);
    }
    private int _numberOfQuestions;
    public int NumberOfQuestions
    {
        get => _numberOfQuestions;
        set => SetProperty(ref _numberOfQuestions, value);
    }

    #endregion

}