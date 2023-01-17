﻿using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.Models.CharCreation;
using LVG.DND.streaming.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LVG.DND.streaming
{
    internal class StreamClasses : BaseStream
    {
        List<CharClass> classes = new List<CharClass>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamClasses()
        {
            PushClasses();
        }
        private void CreateClassFile(CharClass charClass, string basepath)
        {
            var txtName = charClass.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(charClass));
        }
        private void PushClasses()
        {
            var pathRaces = Path.Combine(basepath, @"Data\Classes\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddClasses();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathRaces);

            foreach (CharClass charClass in classes)
            {
                CreateClassFile(charClass, pathRaces);
            }

        }

        public async Task<List<CharClass>> GetAllClasses()
        {
            List<CharClass> classes = new List<CharClass>();
            var pathString = Path.Combine(basepath, "Data\\Classes\\");

            var charactersPaths = System.IO.Directory.GetFiles(pathString);
            foreach (var path in charactersPaths)
            {
                CharClass charclass = new CharClass();
                string classString = await File.ReadAllTextAsync(path);
                charclass = JsonConvert.DeserializeObject<CharClass>(classString);
                classes.Add(charclass);
            }
            return classes;
        }

        private void AddClasses()
        {
            classes = new List<CharClass>();

            var hitDiceBH = new Dice();

            #region Blood Hunter
            hitDiceBH.ChangeSize(10);
            classes.Add(new CharClass
            {
                Name = "Blood Hunter",
                Description = "Blood hunters are clever warriors driven by an unending determination to destroy evils old and new. Armed with rites of secretive blood magic and a willingness to sacrifice their own vitality and humanity for their cause, they protect the realms from the shadows — even as they remain ever vigilant against being drawn to the darkness that consumes the monsters they hunt.",
                HitDice = hitDiceBH,
                ArmorProficiencies = new List<string> { ArmorConstants.LIGHT_ARMOR, ArmorConstants.MEDIUM_ARMOR },
                WeaponProficiencies = new List<string> { WeaponsConstants.SIMPLE_WEAPON, WeaponsConstants.MARTIAL_WEAPON },
                ItemProficiencies = new List<string> { "Alchemist's supplies" },
                AbilityScoresProficiencies = new List<string> { SkillNameConstants.Dexterity, SkillNameConstants.Intelligence },
                SkillProficiencies = new List<string>{ SkillNameConstants.Acrobatics, SkillNameConstants.Arcana, SkillNameConstants.Athletics, SkillNameConstants.History, SkillNameConstants.Insight, SkillNameConstants.Investigation, SkillNameConstants.Religion, SkillNameConstants.Survival },
                MeleeWeaponsChoice = new List<ClassWeaponChoice> 
                { 
                    new ClassWeaponChoice{ WeaponName = WeaponsConstants.MARTIAL_WEAPON, Count = 1},
                    new ClassWeaponChoice{ WeaponName = WeaponsConstants.SIMPLE_WEAPON, Count = 2},
                },
                RangedWeaponsChoice = new List<ClassWeaponChoice> 
                { 
                    new ClassWeaponChoice{ WeaponName = "Light crossbow", Count = 1, Ammo = 20},
                    new ClassWeaponChoice{ WeaponName = "Hand crossbow", Count = 1, Ammo = 20}
                },
                ArmorChoice = new List<string>{"Studded Leather Armor", "Scale mail armor"},
                ClassLevels = new List<ClassLevel>
                {
                    new ClassLevel
                    {
                        Level = 1,
                        SpecialSkillDice = "1d4",
                        ClassSpells = new List<string>{"Hunter's Bane", "Blood Maledict"},
                        SpellChoices = new List<string>{"Blood Curse of the Anxious", "Blood Curse of Binding", "Blood Curse of Bloated Agony", "Blood Curse of Exposure", "Blood Curse of the Eyeless", "Blood Curse of the Marked", "Blood Curse of the Muddled Mind", "Blood Curse of the Soul Eater"},
                        SpellsToLearn = 1
                    }
                }
            });
            #endregion


        }
    }
}
