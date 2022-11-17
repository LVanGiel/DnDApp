using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace LVG.DND.Models
{
    public partial class CharacterCollection : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Character> characters;

        [ObservableProperty]
        int position;
    }
}
