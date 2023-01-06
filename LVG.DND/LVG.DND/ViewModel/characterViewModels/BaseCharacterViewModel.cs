using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class BaseCharacterViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character;
        public BaseCharacterViewModel(Character _character)
        {
            Character = _character;
        }
    }
}
