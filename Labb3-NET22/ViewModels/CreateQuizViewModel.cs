﻿using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;
using Labb3_NET22.Stores;
using Labb3_NET22.Views;

namespace Labb3_NET22.ViewModels;

public class CreateQuizViewModel : ObservableObject
{
    private readonly CreateQuizModel _createQuizModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly FileManager _fileManager;

    public CreateQuizViewModel(CreateQuizModel createQuizModel, NavigationStore navigationStore)
    {
        _createQuizModel = createQuizModel;
        _navigationStore = navigationStore;
        _localNavigationStore = new NavigationStore() { CurrentViewModel = new EditQuizViewModel() };
        _localNavigationStore.CurrentViewModelChanged += OnCurrentLocalViewModelChanged;
        QuizTitle = "Enter quiz title here";
        NumberOfQuestions = 5; // defaultförslag för värdet slidern ska börja på
        CurrentQuestion = 1;
        QuestionAnswers = new string[4];
        SelectedAnswerArray = new bool[4];
        SelectedAnswerArray[0] = true;
        SubmitCommand = new RelayCommand(SetupSubmitCommand, () => true);
        CancelCommand = new RelayCommand(() =>
        {
            navigationStore.CurrentViewModel = new MainMenuViewModel(new MainMenuModel(), _navigationStore);
        });
    }


    public ICommand CancelCommand { get; }
    public ICommand SubmitCommand { get; }

    public ObservableObject CurrentLocalViewModel => _localNavigationStore.CurrentViewModel;

    public Quiz NewQuiz
    {
        get => _createQuizModel.NewQuiz;
        set { SetProperty(_createQuizModel.NewQuiz, value, (v) => _createQuizModel.NewQuiz = v); }
    }
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
    private int _currentQuestion;
    public int CurrentQuestion
    {
        get => _currentQuestion;
        set => SetProperty(ref _currentQuestion, value);
    }
    public string QuestionStatement
    {
        get => _createQuizModel.QuestionStatement;
        set { SetProperty(_createQuizModel.QuestionStatement, value, (v) => _createQuizModel.QuestionStatement = v); }
    }
    public QuestionCategory SelectedCategory
    {
        get => _createQuizModel.Category;
        set
        {
            //if (category != value)
            //{
            //    category = value;
            //    OnPropertyChanged(nameof(SelectedCategory));
            //}
            if (_createQuizModel.Category != value)
            {
                SetProperty(_createQuizModel.Category, value, (v) => _createQuizModel.Category = v);
            }
        }
    }
    public string[] QuestionAnswers
    {
        get => _createQuizModel.QuestionAnswers;
        set { SetProperty(_createQuizModel.QuestionAnswers, value, (v) => _createQuizModel.QuestionAnswers = v); }
    }
    public int CorrectAnswer
    {
        get => _createQuizModel.CorrectAnswer;
        set { SetProperty(_createQuizModel.CorrectAnswer, value, (v) => _createQuizModel.CorrectAnswer = v); }
    }
    private bool[] _selectedAnswerArray;
    public bool[] SelectedAnswerArray
    {
        get => _selectedAnswerArray;
        set => SetProperty(ref _selectedAnswerArray, value);
    }
    private string _testText; // för debug
    public string TestText
    {
        get => _testText;
        set => SetProperty(ref _testText, value);
    }

    #region CommandContent


    private void SetupSubmitCommand()
    {
        _localNavigationStore.CurrentViewModel = new EditQuestionViewModel();
    }

    #endregion

    private void OnCurrentLocalViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentLocalViewModel));
    }

}