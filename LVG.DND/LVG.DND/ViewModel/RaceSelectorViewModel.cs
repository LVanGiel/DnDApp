using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    public partial class RaceSelectorViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Race> races = new List<Race>();

        [ObservableProperty]
        Character character = new Character();
        public RaceSelectorViewModel(Character character)
        {
            AddRaces();
            Character = character;
        }
        
        public RaceSelectorViewModel()
        {
            AddRaces();
        }
        private async void AddRaces()
        {
            Races = await new StreamRaces().GetAllRaces();
        }
    }
}
