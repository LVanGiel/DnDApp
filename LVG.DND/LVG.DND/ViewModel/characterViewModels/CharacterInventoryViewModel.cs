using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterInventoryViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;
        public CharacterInventoryViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
