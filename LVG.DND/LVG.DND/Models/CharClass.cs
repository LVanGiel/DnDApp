using LVG.DND.Models.basemodel;
using LVG.DND.Models.CharCreation;

namespace LVG.DND.Models
{
    public class CharClass : Base
    {
        public string Name { get; set; }
        public List<ClassLevel> ClassLevels { get; set; }
        public string Description { get; set;}
        public Dice HitDice { get; set; }
        public List<string> ArmorProficiencies { get; set; }
        public List<string> WeaponProficiencies { get; set; }
        public List<string> ItemProficiencies { get; set; }
        public List<string> AbilityScoresProficiencies { get; set; }
        public List<string> SkillProficiencies { get; set; }
        public List<ClassWeaponChoice> MeleeWeaponsChoice { get; set; }
        public List<ClassWeaponChoice> RangedWeaponsChoice { get; set; }
        public List<string> ArmorChoice { get; set; }

        public CharClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
