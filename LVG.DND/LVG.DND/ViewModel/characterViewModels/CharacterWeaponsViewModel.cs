using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterWeaponsViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;

        Streaming _stream = new Streaming();
        public CharacterWeaponsViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
