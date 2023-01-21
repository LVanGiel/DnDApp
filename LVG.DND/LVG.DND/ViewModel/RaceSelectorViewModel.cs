using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.Models.basemodel;
using LVG.DND.streaming;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    public partial class CharCreateViewModel : ObservableObject
    {
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
        public CharCreateViewModel(Character character)
        {
            AddRaces();
            Character = character;
        }
        
        public CharCreateViewModel()
        {
            AddRaces();
        }
        private async void AddRaces()
        {
            Races = await new StreamRaces().GetAllRaces();
        }
    }
}
