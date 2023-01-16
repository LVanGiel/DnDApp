using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    [QueryProperty(nameof(Character), "Character")]
    public partial class ClassSelectorViewModel : ObservableObject
    {
        [ObservableProperty]
        List<CharClass> classes;

        [ObservableProperty]
        Character character;
    }
}
