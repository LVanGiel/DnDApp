using LVG.DND.Models;
using Newtonsoft.Json;

namespace LVG.DND.streaming
{
    public class StreamWeapons
    {
        List<Weapon> weapons = new List<Weapon>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamWeapons()
        {
            PushWeapons();
        }
        private void PushWeapons()
        {
            var pathRaces = Path.Combine(basepath, @"Data\Armor\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddWeapons();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathRaces);

            foreach (Weapon weapon in weapons)
            {
                CreateWeaponsFile(weapon, pathRaces);
            }

        }
        private void CreateWeaponsFile(Weapon weapon, string basepath)
        {
            var txtName = weapon.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(weapon));
        }
        internal void CreateFileCheck(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {

                }
            }
        }

        public void AddWeapons()
        {
            
        }

    }
}
