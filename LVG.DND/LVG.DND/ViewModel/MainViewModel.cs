using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LVG.DND.Pages;
using System.Collections.ObjectModel;

namespace LVG.DND.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {        

        public MainViewModel()
        {
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync(nameof(DndDice));
        }
    }
}
