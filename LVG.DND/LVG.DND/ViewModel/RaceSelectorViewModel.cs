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
    public partial class RaceSelectorViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Race> races = new List<Race>();

        public RaceSelectorViewModel()
        {
            var jsonText = File.ReadAllText("C:\\DnDApp\\data\\data.txt");
            var dejson = JsonConvert.DeserializeObject<List<Race>>(jsonText);
            races = dejson;
        }
    }
}
