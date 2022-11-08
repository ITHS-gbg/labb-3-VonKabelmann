using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class EditQuestionViewModel : ObservableObject
{
    private readonly EditQuestionModel _editQuestionModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    public EditQuestionViewModel(EditQuestionModel editQuestionModel, NavigationStore navigationStore, NavigationStore localNavigationStore, QuizStore quizStore)
    {
        _editQuestionModel = editQuestionModel;
        _navigationStore = navigationStore;
        _localNavigationStore = localNavigationStore;
        _quizStore = quizStore;
        _numberOfQuestions = _quizStore.QuestionsAmount;
        _currentQuestionNum = 1;
        QuestionAnswers = new string[4];
        QuestionStatement = string.Empty;
        SelectedAnswerArray = new bool[4];
        SelectedAnswerArray[0] = true;
        CreateCommand = new RelayCommand(SetupCreateCommand);
    }

    #region Properties

    #region Command Properties

    public ICommand CreateCommand { get; }

    #endregion

    private int _numberOfQuestions;

    public int NumberOfQuestions
    {
        get => _numberOfQuestions;
        set => SetProperty(ref _numberOfQuestions, value);
    }

    private int _currentQuestionNum;
    public int CurrentQuestionNum
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
    public int CorrectAnswer { get; set; }
    private bool[] _selectedAnswerArray;
    public bool[] SelectedAnswerArray
    {
        get => _selectedAnswerArray;
        set => SetProperty(ref _selectedAnswerArray, value);
    }

    #endregion

    #region Command Content

    private void SetupCreateCommand()
    {
        if (QuestionAnswers.Any(string.IsNullOrEmpty) || string.IsNullOrEmpty(QuestionStatement))
        {
            MessageBox.Show("All fields must contain something.", "Empty field found", MessageBoxButton.OK);
        }
        else
        {
            for (int i = 0; i < SelectedAnswerArray.Length; i++)
            {
                if (SelectedAnswerArray[i] == true) CorrectAnswer = i;
            }
            _quizStore.CurrentQuiz.AddQuestion(QuestionStatement, CorrectAnswer, SelectedCategory, QuestionAnswers);
            QuestionAnswers = new string[4];
            QuestionStatement = string.Empty;
            if (_currentQuestionNum == _numberOfQuestions)
            {
                var task = _quizStore.SaveQuizToFileAsync();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(new MainMenuModel(), _navigationStore);
            }
            CurrentQuestionNum++;
        }
    }

    #endregion
}