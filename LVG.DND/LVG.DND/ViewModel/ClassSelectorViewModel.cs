using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;
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
        public ClassSelectorViewModel()
        {
            AddClasses();
        }
        public ClassSelectorViewModel(Character character)
        {
            Character = character;
            AddClasses();
        }
        private async void AddClasses()
        {
            Classes = await new StreamClasses().GetAllClasses();
        }
    }
}
