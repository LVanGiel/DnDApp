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
        const string activeCharacterString = "ActiveCharacter.txt";
        string basepath = FileSystem.Current.AppDataDirectory;
        List<Race> races = new List<Race>();
        public Streaming()
        {
            StreamData();
            CreateActiveCharacterFile();
        }
        public async Task<List<Character>> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();
            var pathString = Path.Combine(basepath, "Characters\\");
           // var path = Path.Combine(pathString, txtName);

            var charactersPaths = System.IO.Directory.GetFiles(pathString);
            foreach (var path in charactersPaths)
            {
                Character character = new Character();
                string characterString = await File.ReadAllTextAsync(path);
                character = JsonConvert.DeserializeObject<Character>(characterString);
                characters.Add(character);
            }
            return characters;
        }
        private void CreateActiveCharacterFile()
        {
            var path = Path.Combine(basepath, activeCharacterString);
            CreateFileCheck(path);
        }
        private void StreamData()
        {
            var path = Path.Combine(basepath, @"Data\Races.txt");
            var pathString = Path.Combine(basepath, "Data\\");
            AddRaces();

            System.IO.Directory.CreateDirectory(pathString);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(races));
        }

        private void CreateFileCheck(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {

                }
            }
        }

        public async Task<Character> ChangeCharacter(Character character)
        {
            if (character.Name == null || character.Name == "")
            {
                return null;
            }
            var txtName = character.Name.Replace(" ", "") + ".txt";
            var pathString = Path.Combine(basepath, "Characters\\");
            var path = Path.Combine(pathString, txtName);
            var activeCharacterPath = Path.Combine(basepath, activeCharacterString);

            System.IO.Directory.CreateDirectory(pathString);
            if (File.Exists(path)) 
            {
                var characterstring = await File.ReadAllTextAsync(path);
                character = JsonConvert.DeserializeObject<Character>(characterstring);
            }
            else
            {
                CreateFileCheck(path);
                await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(character));
            }

            await File.WriteAllTextAsync(activeCharacterPath, path);

            return character;
        }

        public async Task<Character> SaveCharacter(Character character)
        {
            var txtName = character.Name.Replace(" ", "") + ".txt";
            var pathString = Path.Combine(basepath, "Characters\\");
            var path = Path.Combine(pathString, txtName);
            
            System.IO.Directory.CreateDirectory(pathString);
            CreateFileCheck(path);

            await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(character));
               
            return character;
        }
        public async Task<Character> LoadCharacter()
        {
            var activeCharacterPath = Path.Combine(basepath, activeCharacterString);
            string path = await File.ReadAllTextAsync(activeCharacterPath);

            string characterString = await File.ReadAllTextAsync(path);

            Character character  = JsonConvert.DeserializeObject<Character>(characterString);

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
