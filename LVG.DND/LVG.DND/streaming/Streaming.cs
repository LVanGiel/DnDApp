using LVG.DND.Models;
using LVG.DND.streaming.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.streaming
{
    internal class Streaming : BaseStream
    {
        const string activeCharacterString = "ActiveCharacter.txt";
        string basepath = FileSystem.Current.AppDataDirectory;
        public Streaming()
        {
            StreamData();
            CreateActiveCharacterFile();
        }

        public async void SaveJokmir()
        {
            string filePath = "JokmirBravarus.txt";
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);
            var result =  await reader.ReadToEndAsync();

            Character jokmir = new Character();
            jokmir = JsonConvert.DeserializeObject<Character>(result);

            await ChangeCharacter(jokmir);
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();
            var pathString = Path.Combine(basepath, "Characters\\");

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
            var racesStream = new StreamRaces();
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

            if(path == "" || path == null)
            {
                return new Character();
            }
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
    }
}
