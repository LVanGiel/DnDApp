using LVG.DND.Models.basemodel;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Character : Base
    {
        public Dice HitpointDice { get; set; }

        //internal variables
        public CharClass Class { get; set; }
        public Race Race { get; set; }
        public string Background { get; set; }

        //roleplay stats
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Hieght { get; set; }

        //equipment
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armor { get; set; }
        public List<string> Items { get; set; }

        //abilities and skills
        public List<Weapon> WeaponProficiencies { get; set; }
        public List<Armor> ArmorProficiencies { get; set; }
        public List<Item> ItemProficiencies { get; set; }
        public List<AbilityScore> SavingThrowProficiencies { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
        //public List<AbilityScore> AbilityScores { get; set; }
        public List<Skill> Skills { get; set; }

        //spells and cantrips
        public List<string> Spells { get; set; }
        public List<string> Cantrips { get; set; }

        //chosen personalities
        public string ChosenBackground { get; set; }
        public string ChosenPersonalityTrait { get; set; }
        public string ChosenIdeal { get; set; }
        public string ChosenBond { get; set; }
        public string ChosenFlaw { get; set; }

        //character saving throws       MAYBE make seperate class for these
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        //other points
        public int Perception { get; set; }
        public int ArmorPoints { get; set; }
        public int Health { get; set; }
        public int Initiative { get; set; }
        public int BaseSpeed { get; set; }
        public int Xp { get; set; }
        public bool UsesXp { get; set; }

        //death saves
        public int Success { get; set; }
        public int Fail { get; set; }

        public Character()
        {
        }
    }
}
