using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    public partial class AbilityScoresViewModel : ObservableObject
    {
        [ObservableProperty]
        List<int> diceScores = new List<int>();

        [ObservableProperty]
        Character character = new Character();

        public AbilityScoresViewModel()
        {

        }

        public AbilityScoresViewModel(Character character)
        {
            Character = character;
        }
    }
}
