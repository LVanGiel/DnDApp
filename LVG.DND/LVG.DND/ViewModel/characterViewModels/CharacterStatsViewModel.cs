using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;

namespace LVG.DND.ViewModel.characterViewModels
{
    public partial class CharacterStatsViewModel : ObservableObject
    {
        [ObservableProperty]
        public Character character = new Character();
        public CharacterStatsViewModel()
        {
            
        }
        public CharacterStatsViewModel(Character _character)
        {
            character = _character;
        }
    }
}
