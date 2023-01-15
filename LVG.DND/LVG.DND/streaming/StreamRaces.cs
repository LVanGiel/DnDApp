using LVG.DND.Models;
using LVG.DND.streaming.Base;
using Newtonsoft.Json;

namespace LVG.DND.streaming
{
    internal class StreamRaces : BaseStream
    {
        List<Race> races = new List<Race>();
        string basepath = FileSystem.Current.AppDataDirectory;
        private void PushRaces()
        {
            var path = Path.Combine(basepath, @"Data\Races.txt");
            var pathString = Path.Combine(basepath, "Data\\");
            AddRaces();

            System.IO.Directory.CreateDirectory(pathString);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(races));
        }
        private void AddRaces()
        {
            var bloodHunter = new Race() { Name = "Blood Hunter", Id = new Guid() };
            races.Add(bloodHunter);
        }
    }
}
