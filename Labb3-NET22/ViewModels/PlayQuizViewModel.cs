using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class PlayQuizViewModel : ObservableObject
{
    #region Readonly Fields

    private readonly PlayQuizModel _playQuizModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    #endregion


    public PlayQuizViewModel(PlayQuizModel playQuizModel, NavigationStore navigationStore)
    {
        _playQuizModel = playQuizModel;
        _navigationStore = navigationStore;
        _quizStore = new QuizStore();
        _localNavigationStore = new NavigationStore();
        _localNavigationStore.CurrentViewModel = new SelectQuizViewModel(new SelectQuizModel(), _navigationStore, _localNavigationStore, _quizStore);
        _localNavigationStore.CurrentViewModelChanged += OnCurrentLocalViewModelChanged;
        OnPropertyChanged(nameof(QuizList));
        CancelCommand = new RelayCommand(() =>
        {
            navigationStore.CurrentViewModel = new MainMenuViewModel(new MainMenuModel(), _navigationStore);
        });
    }

    private Quiz _selectedQuiz;
    public Quiz SelectedQuiz
    {
        get => _selectedQuiz;
        set => SetProperty(ref _selectedQuiz, value);
    }
    public QuestionCategory SelectedCategory
    {
        get => _playQuizModel.Category;
        set
        {
            //if (category != value)
            //{
            //    category = value;
            //    OnPropertyChanged(nameof(SelectedCategory));
            //}
            if (_playQuizModel.Category != value)
            {
                SetProperty(_playQuizModel.Category, value, (v) => _playQuizModel.Category = v);
            }
        }
    }
    public ObservableCollection<Quiz> QuizList
    {
        get => new ObservableCollection<Quiz>(_playQuizModel.QuizList);
    }
    public ICommand CancelCommand { get; }
    public ObservableObject CurrentLocalViewModel => _localNavigationStore.CurrentViewModel;
    private void OnCurrentLocalViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentLocalViewModel));
    }
}