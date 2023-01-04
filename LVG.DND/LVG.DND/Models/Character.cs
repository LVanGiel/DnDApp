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
        public int TemporaryHealth { get; set; }
        public int Initiative { get; set; }
        public int BaseSpeed { get; set; }
        public int Level { get; set; }
        public int ArmorPoints { get; set; }

        //skills and abilities
        public int PassivePerception { get; set; }

        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get
            {
                return proficiencyBonus;
            }
            set
            {
                proficiencyBonus = value;
                UpdateProficiencyBonus(value);
            }
        }
        #region Death Saves
        public Skill StrengthSave { get; set; }
        public Skill DexteritySave { get; set; }
        public Skill ConstitutionSave { get; set; }
        public Skill IntelligenceSave { get; set; }
        public Skill WisdomSave { get; set; }
        public Skill CharismaSave { get; set; }
        #endregion

        #region Ability Scores
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
        #endregion

        #region Skills
        public Skill Acrobatics { get; set; }
        public Skill AnimalHandling { get; set; }
        public Skill Arcana { get; set; }
        public Skill Athletics { get; set; }
        public Skill Deception { get; set; }
        public Skill History { get; set; }
        public Skill Insight { get; set; }
        public Skill Intimidation { get; set; }
        public Skill Investigation { get; set; }
        public Skill Medicine { get; set; }
        public Skill Nature { get; set; }
        public Skill Perception { get; set; }
        public Skill Performance { get; set; }
        public Skill Persuasion { get; set; }
        public Skill Religion { get; set; }
        public Skill SleightOfHand { get; set; }
        public Skill Stealth { get; set; }
        public Skill Survival { get; set; }
        #endregion

        public List<Weapon> Weapons { get; set; }

        //spells and cantrips
        public List<Spell> Spells { get; set; }
        public List<Spell> Cantrips { get; set; }
        public string SpellClass { get; set; }
        public string CastingAbility { get; set; }
        public int SpellSaveDC { get; set; }
        public int SpellAttackBonus { get; set; }

        #region Spellslots
        public int SpellSlotsLevel1 { get; set; }
        public int SpellSlotsLevel2 { get; set; }
        public int SpellSlotsLevel3 { get; set; }
        public int SpellSlotsLevel4 { get; set; }
        public int SpellSlotsLevel5 { get; set; }
        public int SpellSlotsLevel6 { get; set; }
        public int SpellSlotsLevel7 { get; set; }
        public int SpellSlotsLevel8 { get; set; }
        public int SpellSlotsLevel9 { get; set; }
        public int SpellSlotsLevel1Max { get; set; }
        public int SpellSlotsLevel2Max { get; set; }
        public int SpellSlotsLevel3Max { get; set; }
        public int SpellSlotsLevel4Max { get; set; }
        public int SpellSlotsLevel5Max { get; set; }
        public int SpellSlotsLevel6Max { get; set; }
        public int SpellSlotsLevel7Max { get; set; }
        public int SpellSlotsLevel8Max { get; set; }
        public int SpellSlotsLevel9Max { get; set; }
        #endregion

        public List<Armor> Armor { get; set; }
        public List<string> Items { get; set; }


        public CharClass Class { get; set; }
        public Race Race { get; set; }
        public Background Background { get; set; }

        //roleplay stats
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Hieght { get; set; }



        //abilities and skills
        public List<Weapon> WeaponProficiencies { get; set; }
        public List<Armor> ArmorProficiencies { get; set; }
        public List<Item> ItemProficiencies { get; set; }

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
            Weapons = new List<Weapon>();
            FillSkills();
            FillDeathSaves();
            FillAbilityScores();
            Spells = new List<Spell>();
            Cantrips = new List<Spell>();
        }
        private void FillDeathSaves()
        {
            StrengthSave = new Skill(SkillNameConstants.Strength);
            ConstitutionSave = new Skill(SkillNameConstants.Constitution);
            DexteritySave = new Skill(SkillNameConstants.Dexterity);
            IntelligenceSave = new Skill(SkillNameConstants.Intelligence);
            WisdomSave = new Skill(SkillNameConstants.Wisdom);
            CharismaSave = new Skill(SkillNameConstants.Charisma);
        }
        private void FillSkills()
        {
            Acrobatics = new Skill(SkillNameConstants.Acrobatics);
            AnimalHandling = new Skill(SkillNameConstants.AnimalHandling);
            Arcana = new Skill(SkillNameConstants.Arcana);
            Athletics = new Skill(SkillNameConstants.Athletics);
            Deception = new Skill(SkillNameConstants.Deception);

            History = new Skill(SkillNameConstants.History);
            Insight = new Skill(SkillNameConstants.Insight);
            Intimidation = new Skill(SkillNameConstants.Intimidation);
            Investigation = new Skill(SkillNameConstants.Investigation);
            Medicine = new Skill(SkillNameConstants.Medicine);

            Nature = new Skill(SkillNameConstants.Nature);
            Perception = new Skill(SkillNameConstants.Perception);
            Performance = new Skill(SkillNameConstants.Performance);
            Persuasion = new Skill(SkillNameConstants.Persuasion);
            Religion = new Skill(SkillNameConstants.Religion);

            SleightOfHand = new Skill(SkillNameConstants.SleightOfHand);
            Stealth = new Skill(SkillNameConstants.Stealth);
            Survival = new Skill(SkillNameConstants.Survival);
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
            if (abilityScore.Name == SkillNameConstants.Strength)
            {
                StrengthSave.Bonus = abilityScore.Bonus;
                Athletics.Bonus = abilityScore.Bonus;
            }
            if (abilityScore.Name == SkillNameConstants.Dexterity)
            {
                DexteritySave.Bonus = abilityScore.Bonus;
                Acrobatics.Bonus = abilityScore.Bonus;
                SleightOfHand.Bonus = abilityScore.Bonus;
                Stealth.Bonus = abilityScore.Bonus;
            }
            if (abilityScore.Name == SkillNameConstants.Constitution)
            {
                ConstitutionSave.Bonus = abilityScore.Bonus;
            }
            if (abilityScore.Name == SkillNameConstants.Intelligence)
            {
                IntelligenceSave.Bonus = abilityScore.Bonus;
                Arcana.Bonus = abilityScore.Bonus;
                History.Bonus = abilityScore.Bonus;
                Investigation.Bonus = abilityScore.Bonus;
                Nature.Bonus = abilityScore.Bonus;
                Religion.Bonus = abilityScore.Bonus;
            }
            if (abilityScore.Name == SkillNameConstants.Wisdom)
            {
                WisdomSave.Bonus = abilityScore.Bonus;
                AnimalHandling.Bonus = abilityScore.Bonus;
                Insight.Bonus = abilityScore.Bonus;
                Medicine.Bonus = abilityScore.Bonus;
                Perception.Bonus = abilityScore.Bonus ;
                Survival.Bonus = abilityScore.Bonus ;
            }
            if (abilityScore.Name == SkillNameConstants.Charisma)
            {
                CharismaSave.Bonus = abilityScore.Bonus;
                Deception.Bonus = abilityScore.Bonus;
                Intimidation.Bonus = abilityScore.Bonus;
                Performance.Bonus = abilityScore.Bonus;
                Persuasion.Bonus = abilityScore.Bonus;
            }
        }
        public void UpdateSkills()
        {
            UpdateAbilityScore(Strength);
            UpdateAbilityScore(Constitution);
            UpdateAbilityScore(Dexterity);
            UpdateAbilityScore(Intelligence);
            UpdateAbilityScore(Wisdom);
            UpdateAbilityScore(Charisma);
        }
        private void UpdateProficiencyBonus(int bonus)
        {
            Acrobatics.ProficiencyBonus = Acrobatics.ProficiencyBonus > 0 ? bonus : 0;
            AnimalHandling.ProficiencyBonus = AnimalHandling.ProficiencyBonus > 0 ? bonus : 0;
            Arcana.ProficiencyBonus = Arcana.ProficiencyBonus > 0 ? bonus : 0;
            Athletics.ProficiencyBonus = Athletics.ProficiencyBonus > 0 ? bonus : 0;
            Deception.ProficiencyBonus = Deception.ProficiencyBonus > 0 ? bonus : 0;

            History.ProficiencyBonus = History.ProficiencyBonus > 0 ? bonus : 0;
            Insight.ProficiencyBonus = Insight.ProficiencyBonus > 0 ? bonus : 0;
            Intimidation.ProficiencyBonus = Intimidation.ProficiencyBonus > 0 ? bonus : 0;
            Investigation.ProficiencyBonus = Investigation.ProficiencyBonus > 0 ? bonus : 0;
            Medicine.ProficiencyBonus = Medicine.ProficiencyBonus > 0 ? bonus : 0;

            Nature.ProficiencyBonus = Nature.ProficiencyBonus > 0 ? bonus : 0;
            Perception.ProficiencyBonus = Perception.ProficiencyBonus > 0 ? bonus : 0;
            Performance.ProficiencyBonus = Performance.ProficiencyBonus > 0 ? bonus : 0;
            Persuasion.ProficiencyBonus = Persuasion.ProficiencyBonus > 0 ? bonus : 0;
            SleightOfHand.ProficiencyBonus = SleightOfHand.ProficiencyBonus > 0 ? bonus : 0;

            Stealth.ProficiencyBonus = Stealth.ProficiencyBonus > 0 ? bonus : 0;
            Survival.ProficiencyBonus = Survival.ProficiencyBonus > 0 ? bonus : 0;
            Acrobatics.ProficiencyBonus = Acrobatics.ProficiencyBonus > 0 ? bonus : 0;
        }
    }
}