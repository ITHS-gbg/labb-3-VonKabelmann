using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class EditQuizViewModel : ObservableObject
{
    #region Readonly Fields

    private readonly EditQuizModel _editQuizModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    #endregion


    public EditQuizViewModel(EditQuizModel editQuizModel, NavigationStore navigationStore, NavigationStore localNavigationStore, QuizStore quizStore)
    {
        _editQuizModel = editQuizModel;
        _navigationStore = navigationStore;
        _localNavigationStore = localNavigationStore;
        _quizStore = quizStore;
        _quizTitle = string.Empty;
        _numberOfQuestions = 3;
        CreateCommand = new RelayCommand(() =>
        {
            if (_quizTitle != string.Empty)
            {
                quizStore.QuestionsAmount = _numberOfQuestions;
                quizStore.CurrentQuiz = new Quiz(_quizTitle);
                _localNavigationStore.CurrentViewModel = new EditQuestionViewModel(new EditQuestionModel(), _navigationStore, _localNavigationStore, _quizStore);
            }
            else
            {
                MessageBox.Show("The Title field must not be empty.", "Title error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        });
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