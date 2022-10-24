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
        NumberOfQuestions = 5; // defaultförslag för värdet slidern ska börja på
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

    public string TestText
    {
        get => _createQuizModel.TestText;
        set { SetProperty(_createQuizModel.TestText, value, (v) => _createQuizModel.TestText = v); }
    }

    private Visibility _quizBoxVisibility;
    public Visibility QuizBoxVisibility
    {
        get => _quizBoxVisibility;
        set => SetProperty(ref _quizBoxVisibility, value);
    }
    private Visibility _questionBoxVisibility;
    public Visibility QuestionBoxVisibility
    {
        get => _questionBoxVisibility;
        set => SetProperty(ref _questionBoxVisibility, value);
    }
}