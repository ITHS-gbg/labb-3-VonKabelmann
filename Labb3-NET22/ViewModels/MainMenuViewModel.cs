using System.Linq.Expressions;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Stores;

namespace Labb3_NET22.ViewModels;

public class MainMenuViewModel : ObservableObject
{
    private readonly MainMenuModel _mainMenuModel;
    private readonly NavigationStore _navigationStore;
    public MainMenuViewModel(MainMenuModel mainMenuModel, NavigationStore navigationStore)
    {
        _mainMenuModel = mainMenuModel;
        _navigationStore = navigationStore;
        ExitCommand = new RelayCommand(mainMenuModel.ExitApplication,() => true);
        CreateCommand = new RelayCommand(() =>
        {
            navigationStore.CurrentViewModel = new CreateQuizViewModel(new CreateQuizModel(), _navigationStore);
        });
        PlayCommand = new RelayCommand(() =>
        {
            navigationStore.CurrentViewModel = new PlayQuizViewModel(new PlayQuizModel(), _navigationStore);
        });
        //EditCommand = new RelayCommand(() =>
        //{
            
        //})
    }
    public ICommand PlayCommand { get; }
    public ICommand CreateCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand ExitCommand { get; }
}