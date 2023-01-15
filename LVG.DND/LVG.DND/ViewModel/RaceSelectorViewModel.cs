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
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, @"Data\Races.txt");
        public RaceSelectorViewModel(Character character)
        {
            var jsonText = File.ReadAllText(path);
            var dejson = JsonConvert.DeserializeObject<List<Race>>(jsonText);
            races = dejson;

            Character = character;
        }
        public RaceSelectorViewModel()
        {
            var jsonText = File.ReadAllText(path);
            var dejson = JsonConvert.DeserializeObject<List<Race>>(jsonText);
            races = dejson;
        }
    }
}
