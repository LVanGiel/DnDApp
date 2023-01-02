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
        string basepath = FileSystem.Current.AppDataDirectory;
        List<Race> races = new List<Race>();
        public Streaming()
        {
            var path = Path.Combine(basepath, @".\data.txt");
            AddRaces();

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(races));
        }

        public async Task<Character> SaveCharacter(Character character)
        {
            var path = Path.Combine(basepath, @".\Character.txt");

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            bool whileBool = false;
            while (!whileBool)
            {
                try
                {
                    await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(character));
                    whileBool = true;
                }
                catch (Exception)
                {
                    continue;
                }
               
            }
            return character;
        }
        public async Task<Character> LoadCharacter()
        {
            var path = Path.Combine(basepath, @".\Character.txt");

            if (!File.Exists(path))
            {
                return new Character();
            }
            string characterString = await File.ReadAllTextAsync(path);

            Character character = new Character();
            character.Skills.Clear();
            character.AbilityScores.Clear();
            character = JsonConvert.DeserializeObject<Character>(characterString);
            character.AbilityScores.RemoveRange(6, character.AbilityScores.Count - 6);
            character.Skills.RemoveRange(6, character.Skills.Count - 18);

            if (character != null)
            {
                return character;
            }
            else
            {
                return new Character();
            }
        }

        private void AddRaces()
        {
            var bloodHunter = new Race() { Name = "Blood Hunter", Id = new Guid() };
            races.Add(bloodHunter);
        }
    }
}
