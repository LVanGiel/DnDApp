using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.Models.basemodel;
using LVG.DND.streaming;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    public partial class CharCreateViewModel : ObservableObject
    {
        //races selections
        [ObservableProperty]
        List<Race> races = new List<Race>();

        [ObservableProperty]
        Character character = new Character();

        [ObservableProperty]
        List<Item> selectedRaceItems = new List<Item>();

        [ObservableProperty]
        List<Item> selectedRaceAbilityScores = new List<Item>();

        [ObservableProperty]
        List<Item> selectedRaceLanguages = new List<Item>();

        [ObservableProperty]
        List<int> diceScores = new List<int>();

        [ObservableProperty]
        List<Background> backgrounds = new List<Background>();

        [ObservableProperty]
        List<CharClass> classes = new List<CharClass>();


        public CharCreateViewModel(Character character)
        {
            Character = character;
        }
        
        public CharCreateViewModel()
        {
        }
    }
}
