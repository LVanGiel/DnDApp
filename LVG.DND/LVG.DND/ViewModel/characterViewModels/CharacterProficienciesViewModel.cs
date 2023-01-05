using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterProficienciesViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;

        Streaming _stream = new Streaming();
        public CharacterProficienciesViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
