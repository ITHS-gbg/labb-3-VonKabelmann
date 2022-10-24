using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.Stores;
using Labb3_NET22.ViewModels;

namespace Labb3_NET22.DataModels;

public class MainMenuModel
{
    public void ExitApplication()
    {
        Environment.Exit(0);
    }
    
}