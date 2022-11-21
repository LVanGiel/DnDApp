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
        Character character = new Character();
        public ClassSelectorViewModel()
        {
            var jsonText = File.ReadAllText("C:\\DnDApp\\data\\data.txt");
            var dejson = JsonConvert.DeserializeObject<List<CharClass>>(jsonText);
            classes = dejson;
        }
        public ClassSelectorViewModel(Character character)
        {
            var jsonText = File.ReadAllText("C:\\DnDApp\\data\\data.txt");
            var dejson = JsonConvert.DeserializeObject<List<CharClass>>(jsonText);
            classes = dejson;

            Character = character;
        }
    }
}
