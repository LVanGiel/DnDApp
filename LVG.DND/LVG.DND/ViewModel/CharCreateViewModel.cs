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

        //class selections
        [ObservableProperty]
        List<CharClass> classes = new List<CharClass>();


        public CharCreateViewModel(Character character)
        {
            AddRaces();
            AddClasses();
            Character = character;
        }
        
        public CharCreateViewModel()
        {
            AddRaces();
            AddClasses();
        }
        private async void AddRaces()
        {
            Races = await new StreamRaces().GetAllRaces();
        }
        private async void AddClasses()
        {
            Classes = await new StreamClasses().GetAllClasses();
        }
    }
}
