using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace LVG.DND.Models
{
    public class CharacterCollection : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Character> CharacterList = new ObservableCollection<Character>();
    }
}
