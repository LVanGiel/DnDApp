using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.ViewModel
{
    public partial class BackgroundSelectorViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Background> backgrounds = new List<Background>();

        [ObservableProperty]
        Character character = new Character();
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, @".\data.txt");
        public BackgroundSelectorViewModel()
        {
            var jsonText = File.ReadAllText(path);
            var dejson = JsonConvert.DeserializeObject<List<Background>>(jsonText);
            backgrounds = dejson;
        }
        public BackgroundSelectorViewModel(Character character)
        {
            var jsonText = File.ReadAllText(path);
            var dejson = JsonConvert.DeserializeObject<List<Background>>(jsonText);
            backgrounds = dejson;

            Character = character;
        }
    }
}
