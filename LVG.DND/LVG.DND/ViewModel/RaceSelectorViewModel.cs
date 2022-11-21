using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
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
            var jsonText = File.ReadAllText("C:\\DnDApp\\data\\data.txt");
            var dejson = JsonConvert.DeserializeObject<List<Race>>(jsonText);
            races = dejson;

            Character = character;
        }
        public RaceSelectorViewModel()
        {
            var jsonText = File.ReadAllText("C:\\DnDApp\\data\\data.txt");
            var dejson = JsonConvert.DeserializeObject<List<Race>>(jsonText);
            races = dejson;
        }
    }
}
