using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;

namespace LVG.DND.ViewModel
{
    public partial class CharacterCollectionPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Character> characters = new List<Character>();
        public CharacterCollectionPageViewModel()
        {
            FillCharacters();
        }
        private async void FillCharacters()
        {
            characters = await (new Character()).GetAllCharacter();
        }
    }
}
