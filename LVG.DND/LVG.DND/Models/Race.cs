﻿using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    internal class Race : Base
    {
        public List<AbilityScore> AbilityScores { get; set; }
        public int MaxAge { get; set; }
        public int MaxHeight { get; set; }
        public int BaseSpeed { get; set; }
        public List<Traits> Traits { get; set; }
        public List<Language> Languages { get; set; }
        public List<Cantrip> Cantrips { get; set; }
        public List<Weapon> WeaponProficiencies { get; set; }
        public List<Armor> ArmorProficiencies { get; set; }
        public List<Item> ItemProficiencies { get; set; }
        public List<AbilityScore> SavingThrowProficiencies { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
    }
}
