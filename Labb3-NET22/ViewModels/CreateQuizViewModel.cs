using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;
using Labb3_NET22.Views;

namespace Labb3_NET22.ViewModels;

public class CreateQuizViewModel : ObservableObject
{
    private readonly CreateQuizModel _createQuizModel;
    private readonly NavigationStore _navigationStore;

    public CreateQuizViewModel(CreateQuizModel createQuizModel, NavigationStore navigationStore)
    {
        _createQuizModel = createQuizModel;
        _navigationStore = navigationStore;
        QuizTitle = "Enter quiz title here";
        NumberOfQuestions = 1;
        SubmitCommand = new RelayCommand(() =>
        {
            TestText = createQuizModel.GetTestText();
            QuizTitle = string.Empty;
            NumberOfQuestions = 1;
            QuizBoxVisibility = Visibility.Collapsed;
        }, () => true);
        CancelCommand = new RelayCommand(() =>
        {
            navigationStore.CurrentViewModel = new MainMenuViewModel(new MainMenuModel(), _navigationStore);
        });
    }
    public string QuizTitle
    {
        get => _createQuizModel.QuizTitle;
        set { SetProperty(_createQuizModel.QuizTitle, value, (v) => _createQuizModel.QuizTitle = v); }
    }

    public int NumberOfQuestions
    {
        get => _createQuizModel.NumberOfQuestions;
        set { SetProperty(_createQuizModel.NumberOfQuestions, value, (v) => _createQuizModel.NumberOfQuestions = v); }
    }

    public ICommand CancelCommand { get; }
    public ICommand SubmitCommand { get; }

    private string _testText;
    public string TestText
    {
        get { return _testText; }
        set
        {
            SetProperty(ref _testText, value);
        }
    }

    private Visibility _quizBoxVisibility;
    public Visibility QuizBoxVisibility
    {
        get { return _quizBoxVisibility; }
        set
        {
            SetProperty(ref _quizBoxVisibility, value);
        }
    }
}