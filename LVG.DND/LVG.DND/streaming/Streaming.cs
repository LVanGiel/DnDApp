using LVG.DND.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.streaming
{
    internal class Streaming
    {
        List<Race> races = new List<Race>();
        public Streaming()
        {
            var path = @"C:\DnDApp\data\data.txt";
            AddRaces();

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(races));
        }
        private void AddRaces()
        {
            var bloodHunter = new Race() { Name = "Blood Hunter", Id = new Guid() };
            races.Add(bloodHunter);
        }
    }
}
