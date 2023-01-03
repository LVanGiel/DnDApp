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

        //get set variables
        private AbilityScore strength;
        private AbilityScore dexterity;
        private AbilityScore constitution;
        private AbilityScore intelligence;
        private AbilityScore wisdom;
        private AbilityScore charisma;
        public AbilityScore Strength {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
                UpdateAbilityScore(value);
            }
        }
        public AbilityScore Dexterity {
            get
            {
                return dexterity;
            }
            set
            {
                dexterity = value;
                UpdateAbilityScore(value);
            }
        }
        public AbilityScore Constitution {
            get
            {
                return constitution;
            }
            set
            {
                constitution = value;
                UpdateAbilityScore(value);
            }
        }
        public AbilityScore Intelligence {
            get
            {
                return intelligence;
            }
            set
            {
                intelligence = value;
                UpdateAbilityScore(value);
            }
        }
        public AbilityScore Wisdom {
            get
            {
                return wisdom;
            }
            set
            {
                wisdom = value;
                UpdateAbilityScore(value);
            }
        }
        public AbilityScore Charisma {
            get
            {
                return charisma;
            }
            set
            {
                charisma = value;
                UpdateAbilityScore(value);
            }
        }
        public SkillGroup Skills { get; set; }

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

        //other points
        public int Xp { get; set; }
        public bool UsesXp { get; set; }

        //death saves
        public int Success { get; set; }
        public int Fail { get; set; }

        public Character()
        {
            Id = Guid.NewGuid();
            FillAbilityScores();
            FillSkills();
        }
        private void FillSkills()
        {
            Skills = new SkillGroup();
        }
        private void FillAbilityScores()
        {
            Strength = new AbilityScore(SkillNameConstants.Strength);
            Constitution = new AbilityScore(SkillNameConstants.Constitution);
            Dexterity = new AbilityScore(SkillNameConstants.Dexterity);
            Intelligence = new AbilityScore(SkillNameConstants.Intelligence);
            Wisdom = new AbilityScore(SkillNameConstants.Wisdom);
            Charisma = new AbilityScore(SkillNameConstants.Charisma);

            UpdateAbilityScore(Strength);
            UpdateAbilityScore(Constitution);
            UpdateAbilityScore(Dexterity);
            UpdateAbilityScore(Intelligence);
            UpdateAbilityScore(Wisdom);
            UpdateAbilityScore(Charisma);
        }
        public void UpdateAbilityScore(AbilityScore abilityScore)
        {
            if (Skills == null)
            {
                FillSkills();
            }
            if (abilityScore.Name == SkillNameConstants.Strength)
            {
                Skills.Athletics.Bonus = abilityScore.Bonus + Skills.Athletics.ClassBonus;
            }
            if (abilityScore.Name == SkillNameConstants.Dexterity)
            {
                Skills.Acrobatics.Bonus = abilityScore.Bonus + Skills.Acrobatics.ClassBonus;
                Skills.SleightOfHand.Bonus = abilityScore.Bonus + Skills.SleightOfHand.ClassBonus;
                Skills.Stealth.Bonus = abilityScore.Bonus + Skills.Stealth.ClassBonus ;
            }
            if (abilityScore.Name == SkillNameConstants.Constitution)
            {

            }
            if (abilityScore.Name == SkillNameConstants.Intelligence)
            {
                Skills.Arcana.Bonus = abilityScore.Bonus + Skills.Arcana.ClassBonus;
                Skills.History.Bonus = abilityScore.Bonus + Skills.History.ClassBonus;
                Skills.Investigation.Bonus = abilityScore.Bonus + Skills.Investigation.ClassBonus;
                Skills.Nature.Bonus = abilityScore.Bonus + Skills.Nature.ClassBonus;
                Skills.Religion.Bonus = abilityScore.Bonus + Skills.Religion.ClassBonus;
            }
            if (abilityScore.Name == SkillNameConstants.Wisdom)
            {
                Skills.AnimalHandling.Bonus = abilityScore.Bonus + Skills.AnimalHandling.ClassBonus;
                Skills.Insight.Bonus = abilityScore.Bonus + Skills.Insight.ClassBonus;
                Skills.Medicine.Bonus = abilityScore.Bonus + Skills.Medicine.ClassBonus;
                Skills.Perception.Bonus = abilityScore.Bonus + Skills.Perception.ClassBonus ;
                Skills.Survival.Bonus = abilityScore.Bonus + Skills.Survival.ClassBonus ;
            }
            if (abilityScore.Name == SkillNameConstants.Charisma)
            {
                Skills.Deception.Bonus = abilityScore.Bonus + Skills.Deception.ClassBonus;
                Skills.Intimidation.Bonus = abilityScore.Bonus + Skills.Intimidation.ClassBonus;
                Skills.Performance.Bonus = abilityScore.Bonus + Skills.Performance.ClassBonus;
                Skills.Persuasion.Bonus = abilityScore.Bonus + Skills.Persuasion.ClassBonus;
            }
        }
    }
}
