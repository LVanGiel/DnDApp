using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterSkillsAndAbilityscoresViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;
        [ObservableProperty]
        public bool isLevelEditable = false;

        Streaming _stream = new Streaming();
        public CharacterSkillsAndAbilityscoresViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
