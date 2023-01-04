using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterSpellsViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;

        Streaming _stream = new Streaming();
        public CharacterSpellsViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
