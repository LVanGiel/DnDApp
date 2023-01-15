using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using Newtonsoft.Json;

namespace LVG.DND.ViewModel
{
    public partial class ClassSelectorViewModel : ObservableObject
    {
        [ObservableProperty]
        List<CharClass> classes = new List<CharClass>();

        [ObservableProperty]
        List<Race> races = new List<Race>();

        [ObservableProperty]
        Character character = new Character();
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, @"Data\Races.txt");
        public ClassSelectorViewModel()
        {
            var classText = File.ReadAllText(path);
            var dejsonClass = JsonConvert.DeserializeObject<List<CharClass>>(classText);
            classes = dejsonClass;

            var raceText = File.ReadAllText(path);
            var dejsonRace = JsonConvert.DeserializeObject<List<Race>>(raceText);
            Races = dejsonRace;
        }
        public ClassSelectorViewModel(Character character)
        {
            var classText = File.ReadAllText(path);
            var dejsonClass = JsonConvert.DeserializeObject<List<CharClass>>(classText);
            classes = dejsonClass;
            Character = character;

            var raceText = File.ReadAllText(path);
            var dejsonRace = JsonConvert.DeserializeObject<List<Race>>(raceText);
            Races = dejsonRace;
        }
    }
}
