using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class CharClass : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AbilityScore> AbilityScores { get; set; }
        public List<ClassLevel> Levels { get; set; }
        public List<Weapon> WeaponProficiencies { get; set; }
        public List<Armor> ArmorProficiencies { get; set; }
        public List<Item> ItemProficiencies { get; set; }
        public List<AbilityScore> SavingThrowProficiencies { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
        public List<Item> Equipment { get; set; }
        public List<Traits> Traits { get; set; }
        public CharClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
