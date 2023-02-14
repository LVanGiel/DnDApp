using LVG.DND.Models.basemodel;
using LVG.DND.Models.CharCreation;

namespace LVG.DND.Models.CharacterChoices
{
    public class ClassChoice : Base
    {
        public string Name { get; set; }
        public List<ClassLevel> ClassLevels { get; set; }
        public Dice HitDice { get; set; }
        public List<string> ArmorProficiencies { get; set; }
        public List<string> WeaponProficiencies { get; set; }
        public List<string> ItemProficiencies { get; set; }
        public List<string> AbilityScoresProficiencies { get; set; }
        public List<string> SkillProficiencies { get; set; }
        public int SkillProficienciesCount { get; set; }
        public List<Weapon> WeaponsChoices { get; set; }
        public List<Armor> ArmorChoices { get; set; }

        public ClassChoice()
        {
            Id = Guid.NewGuid();
        }
    }
}
