using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class SelectQuizViewModel : ObservableObject
{
    private readonly SelectQuizModel _selectQuizModel;
    private readonly NavigationStore _navigationStore;
    private readonly NavigationStore _localNavigationStore;
    private readonly QuizStore _quizStore;

    public SelectQuizViewModel(SelectQuizModel selectQuizModel, NavigationStore navigationStore, NavigationStore localNavigationStore, QuizStore quizStore)
    {
        _selectQuizModel = selectQuizModel;
        _navigationStore = navigationStore;
        _localNavigationStore = localNavigationStore;
        _quizStore = quizStore;
    }
}