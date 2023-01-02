using LVG.DND.AppConstants;
using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class Character : Base
    {
        public Dice HitpointDice { get; set; }
        //Stats
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Initiative { get; set; }
        public int BaseSpeed { get; set; }
        public int Level { get; set; }
        public int ArmorPoints { get; set; }

        //skills and abilities
        public int PassivePerception { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
        public List<Skill> Skills { get; set; }

        private List<AbilityScore> abilityScores;
        public List<AbilityScore> AbilityScores {
            get
            {
                return abilityScores;
            }
            set
            {
                abilityScores = value;
                UpdateSkills(value);
            }
        }

        //-------------to do


        public CharClass Class { get; set; }
        public Race Race { get; set; }
        public Background Background { get; set; }

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
        public int Xp { get; set; }
        public bool UsesXp { get; set; }

        //death saves
        public int Success { get; set; }
        public int Fail { get; set; }

        //variables
        private SkillNameConstants skillNames = new SkillNameConstants();

        public Character()
        {
            Id = Guid.NewGuid();
            GenerateSkills();
        }

        private void GenerateSkills()
        {
            Skills = new List<Skill>();
            AbilityScores = new List<AbilityScore>();
            if (Skills.Count < 18)
            {
                foreach (string skillName in skillNames.SkillNames)
                {
                    var skill = new Skill(skillName, 0);
                    Skills.Add(skill);
                }
            }
            if (AbilityScores.Count < 6)
            {
                foreach (string abilityScoreName in skillNames.AbilityScoreNames)
                {
                    var abilityScore = new AbilityScore(abilityScoreName, 0);
                    AbilityScores.Add(abilityScore);
                }
            }
        }
        public void UpdateSkills(List<AbilityScore> abilityScores)
        {
            foreach (var skill in Skills)
            {
                foreach (var score in abilityScores)
                {
                    if (skill.AbilityScoreName == score.Name)
                    {
                        skill.Bonus = score.Bonus;
                        skill.BonusText = score.BonusText;
                    }
                }
            }
        }
    }
}
