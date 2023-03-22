using LVG.DND.Models;
using LVG.DND.Models.CharCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.AppConstants
{
    public class ClassConstants
    {
        private static Dice FillDice(int size)
        {
            Dice dice = new Dice();
            dice.ChangeSize(size); 
            return dice;
        }
        public static List<CharClass> GetAll()
        {
            var list = new List<CharClass>();
            list.Add(BLOOD_HUNTER);
            return list;
        }

        public static CharClass BLOOD_HUNTER = new CharClass
        {
            Name = "Blood Hunter",
            Description = "Blood hunters are clever warriors driven by an unending determination to destroy evils old and new. Armed with rites of secretive blood magic and a willingness to sacrifice their own vitality and humanity for their cause, they protect the realms from the shadows — even as they remain ever vigilant against being drawn to the darkness that consumes the monsters they hunt.",
            HitDice = FillDice(10),
            ArmorProficiencies = new List<string> { ArmorConstants.LIGHT_ARMOR, ArmorConstants.MEDIUM_ARMOR },
            WeaponProficiencies = new List<string> { WeaponsConstants.SIMPLE_WEAPON, WeaponsConstants.MARTIAL_WEAPON },
            ItemProficiencies = new List<string> { "Alchemist's supplies" },
            AbilityScoresProficiencies = new List<string> { SkillNameConstants.Dexterity, SkillNameConstants.Intelligence },
            SkillProficiencies = new List<string> { SkillNameConstants.Acrobatics, SkillNameConstants.Arcana, SkillNameConstants.Athletics, SkillNameConstants.History, SkillNameConstants.Insight, SkillNameConstants.Investigation, SkillNameConstants.Religion, SkillNameConstants.Survival },
            SkillProficienciesCount = 3,
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
            ArmorChoice = new List<string> { "Studded Leather Armor", "Scale mail armor" },
            ClassLevels = new List<ClassLevel>
                {
                    new ClassLevel
                    {
                        Level = 1,
                        SpecialSkillDice = "1d4",
                        LevelFeatures = new List<string>{"Hunter's Bane", "Blood Maledict"},
                        SpellChoices = new List<string>{"Blood Curse of the Anxious", "Blood Curse of Binding", "Blood Curse of Bloated Agony", "Blood Curse of Exposure", "Blood Curse of the Eyeless", "Blood Curse of the Marked", "Blood Curse of the Muddled Mind", "Blood Curse of the Soul Eater"},
                        SpellsToLearn = 1
                    },
                    new ClassLevel
                    {
                        Level = 2,
                        SpecialSkillDice = "1d4",
                        LevelFeatures = new List<string>{"Fighting Style", "Crimson Rite"},
                        FeatureChoices  = new List<string>{ "Archery", "Dueling", "Great Weapon Fighting", "Two-Weapon Fighting"},
                        SpellChoices = new List<string>{ "Rite of the Flame", "Rite of the Frozen", "Rite of the Storm"},
                        SpellsToLearn = 1
                    },
                    new ClassLevel
                    {
                        Level = 3,
                        SpecialSkillDice = "1d4",
                        ClassSpells = new List<string>{"Blood Hunter Order"},
                        SubClassChoices = new List<string>{"Order of the Ghostslayer","Order of the Lycan", "Order of the Mutant", "Order of the Profane Soul"},
                        SpellsToLearn = 1
                    }
                }
        };
    }
}
