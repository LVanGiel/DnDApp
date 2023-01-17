using LVG.DND.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.streaming
{
    public class StreamArmor
    {
        List<Armor> armors = new List<Armor>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamArmor()
        {
            PushArmor();
        }
        private void CreateClassFile(Armor charClass, string basepath)
        {
            var txtName = charClass.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(charClass));
        }
        private void PushArmor()
        {
            var pathRaces = Path.Combine(basepath, @"Data\Armor\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddArmor();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathRaces);

            foreach (Armor armor in armors)
            {
                CreateClassFile(armor, pathRaces);
            }

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
        public void AddArmor()
        {
            armors = new List<Armor>
            {
                #region light armor
                new Armor
                {
                    Name = "Padded",
                    ArmorClass = 11,
                    HasStealthDisadvantage = true,
                    Weight = 8,
                    GoldCost = 5,
                    IsLight = true
                }
                ,new Armor
                {
                    Name = "Leather",
                    ArmorClass = 11,
                    HasStealthDisadvantage = false,
                    Weight = 10,
                    GoldCost = 10,
                    IsLight = true
                }
                ,new Armor
                {
                    Name = "Studded Leather",
                    ArmorClass = 12,
                    HasStealthDisadvantage = false,
                    Weight = 13,
                    GoldCost = 45,
                },
                #endregion

                #region medium armor
                new Armor
                {
                    Name = "Hide",
                    ArmorClass = 12,
                    HasStealthDisadvantage = false,
                    Weight = 12,
                    GoldCost = 10,
                    IsMedium = true
                }
                ,new Armor
                {
                    Name = "Chain Shirt",
                    ArmorClass = 13,
                    HasStealthDisadvantage = false,
                    Weight = 20,
                    GoldCost = 50,
                    IsMedium = true
                }
                ,new Armor
                {
                    Name = "Scale Mail",
                    ArmorClass = 14,
                    HasStealthDisadvantage = true,
                    Weight = 45,
                    GoldCost = 50,
                    IsMedium = true
                }
                ,new Armor
                {
                    Name = "Spiked Armor",
                    ArmorClass = 14,
                    HasStealthDisadvantage = true,
                    Weight = 45,
                    GoldCost = 75,
                    IsMedium = true
                }
                ,new Armor
                {
                    Name = "Breastplate",
                    ArmorClass = 14,
                    HasStealthDisadvantage = false,
                    Weight = 20,
                    GoldCost = 400,
                    IsMedium = true
                }
                ,new Armor
                {
                    Name = "Halfplate",
                    ArmorClass = 15,
                    HasStealthDisadvantage = true,
                    Weight = 40,
                    GoldCost = 750,
                    IsMedium = true
                },
                #endregion

                #region heavy armor
                new Armor
                {
                    Name = "Ring Mail",
                    ArmorClass = 14,
                    HasStealthDisadvantage = true,
                    Weight = 40,
                    GoldCost = 30,
                    IsHeavy = true
                }
                ,new Armor
                {
                    Name = "Chain Mail",
                    ArmorClass = 16,
                    HasStealthDisadvantage = true,
                    Weight = 55,
                    GoldCost = 75,
                    IsHeavy = true,
                    StrengthRequirement = 13
                }
                ,new Armor
                {
                    Name = "Splint",
                    ArmorClass = 17,
                    HasStealthDisadvantage = true,
                    Weight = 60 ,
                    GoldCost = 200,
                    IsHeavy = true,
                    StrengthRequirement = 15
                }
                ,new Armor
                {
                    Name = "Plate",
                    ArmorClass = 18,
                    HasStealthDisadvantage = true,
                    Weight = 65,
                    GoldCost = 1500,
                    IsHeavy = true,
                    StrengthRequirement = 15
                },
                #endregion

                #region Shield
                new Armor
                {
                    Name = "Shield",
                    ArmorClass = 2,
                    HasStealthDisadvantage = false,
                    Weight = 6,
                    GoldCost = 10,
                    IsShield = true
                }
                ,
                #endregion
            };
        }
    }
}
