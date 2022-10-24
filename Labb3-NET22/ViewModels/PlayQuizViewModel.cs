using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class PlayQuizViewModel : ObservableObject
{
    private readonly PlayQuizModel _playQuizModel;
    private readonly NavigationStore _navigationStore;

    public PlayQuizViewModel(PlayQuizModel playQuizModel, NavigationStore navigationStore)
    {
        _playQuizModel = playQuizModel;
        _navigationStore = navigationStore;
    }
}