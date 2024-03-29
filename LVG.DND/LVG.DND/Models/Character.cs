﻿using LVG.DND.AppConstants;
using LVG.DND.Models.basemodel;
using LVG.DND.Models.CharacterChoices;
using LVG.DND.streaming;

namespace LVG.DND.Models
{
    public class Character : Base
    {

        public List<AbilityScore> BaseAbilityScores { get; set; }
        public ClassChoice Class { get; set; }
        public SubClass SubClass { get; set; }
        public RaceChoice Race { get; set; }
        public SubRace SubRace { get; set; }
        public Background Background { get; set; }

        #region StoryTelling

        //roleplay stats
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Hair { get; set; }
        public string Skin { get; set; }
        public string Eyes { get; set; }

        public string Alignment { get; set; }
        public string Backstory { get; set; }

        #endregion


        public string Name { get; set; }
        public Dice HitpointDice { get; set; }

        #region stats
        //Stats
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int TemporaryHealth { get; set; }
        public int Initiative { get; set; }
        public int BaseSpeed { get; set; }
        public int FlyingSpeed { get; set; }
        public int FloatingSpeed { get; set; }
        public int SwimmingSpeed { get; set; }
        public int ClimbingSpeed { get; set; }
        public int Level { get; set; }
        public int ArmorPoints { get; set; }

        //death saves
        public int DeathSaveSuccess { get; set; }
        public int DeathSaveFail { get; set; }

        //other points
        public int Xp { get; set; }
        public bool UsesXp { get; set; }
        #endregion

        #region skills and abilities
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
        #endregion

        #region Armor and weapons
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armor { get; set; }
        #endregion

        #region spells and cantrips
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
        #endregion

        #region proficiencies

        //abilities and skills
        public List<string> WeaponProficiencies { get; set; }
        public List<string> ArmorProficiencies { get; set; }
        public List<string> ItemProficiencies { get; set; }
        public List<string> LanguageProficiencies { get; set; }
        #endregion

        #region inventory
        public MoneyBag MoneyPouch { get; set; }
        public List<Item> Items { get; set; }
        public bool HasBagOfHolding { get; set; }
        public MoneyBag BagOfHoldingMoneyPouch { get; set; }
        public List<Item> BagOfHoldingItems { get; set; }
        #endregion

        public List<Trait> Traits { get; set; }

        #region ctor
        Streaming _stream = new Streaming();
        public Character(string name)
        {
            LoadProperties();
            Name = name;
        }
        public Character()
        {
            LoadProperties();
        }
        #endregion

        #region CharUpdates
        public async Task SaveCharacter(Character character)
        {
            await _stream.SaveCharacter(character);
        }
        public async Task SaveCharacter()
        {
            await _stream.SaveCharacter(this);
        }
        public async Task ChangeCharacter(Character character)
        {
            await _stream.ChangeCharacter(character);
        }
        public async Task<List<Character>> GetAllCharacter()
        {
            return await _stream.GetAllCharacters();
        }
        public async Task<Character> GetActiveCharacter()
        {
            return await _stream.LoadCharacter();
        }
        #endregion

        public void AddRace(RaceChoice race)
        {
            Race = race;
            /*BaseSpeed = race.BaseWalkingSpeed;
            FlyingSpeed = race.BaseFlyingSpeed;
            FloatingSpeed = race.BaseFloatingSpeed;
            SwimmingSpeed = race.BaseSwimmingSpeed != 0 ? race.BaseSwimmingSpeed : race.BaseWalkingSpeed / 2;
            ClimbingSpeed = race.BaseClimbingSpeed != 0 ? race.BaseClimbingSpeed : race.BaseWalkingSpeed / 2;
            Traits = AddToListDistinct(Traits, race.Traits);
            LanguageProficiencies = AddToListDistinct(LanguageProficiencies, race.Languages);
            WeaponProficiencies = AddToListDistinct(WeaponProficiencies, race.WeaponProficiencies);
            ItemProficiencies = AddToListDistinct(ItemProficiencies, race.ItemProficiencies);

            foreach (var AS in race.ASBonus)
            {
                switch (AS.AbilityScoreName)
                {
                    case SkillNameConstants.Strength:
                        Strength.RaceBonus = AS.Bonus;
                        break;
                    case SkillNameConstants.Dexterity:
                        Dexterity.RaceBonus = AS.Bonus;
                        break;
                    case SkillNameConstants.Constitution:
                        Constitution.RaceBonus = AS.Bonus;
                        break;
                    case SkillNameConstants.Charisma:
                        Charisma.RaceBonus = AS.Bonus;
                        break;
                    case SkillNameConstants.Wisdom:
                        Wisdom.RaceBonus = AS.Bonus;
                        break;
                    case SkillNameConstants.Intelligence:
                        Intelligence.RaceBonus = AS.Bonus;
                        break;
                    default:
                        break;
                }
            }
            RefreshCharacterProperties();*/
        }
        public void AddSubRace(SubRace subRace)
        {
            SubRace = subRace;
            /*BaseSpeed = subRace.BaseWalkingSpeed != 0 ? subRace.BaseWalkingSpeed : BaseSpeed;
            FlyingSpeed = subRace.BaseFlyingSpeed != 0 ? subRace.BaseFlyingSpeed : FlyingSpeed;
            FloatingSpeed = subRace.BaseFloatingSpeed != 0 ? subRace.BaseFloatingSpeed : FloatingSpeed;
            SwimmingSpeed = subRace.BaseSwimmingSpeed != 0 ? subRace.BaseSwimmingSpeed : subRace.BaseWalkingSpeed / 2;
            ClimbingSpeed = subRace.BaseClimbingSpeed != 0 ? subRace.BaseClimbingSpeed : subRace.BaseWalkingSpeed / 2;
            Traits = AddToListDistinct(Traits, subRace.Traits);
            LanguageProficiencies = AddToListDistinct(LanguageProficiencies, subRace.Languages);
            WeaponProficiencies = AddToListDistinct(WeaponProficiencies, subRace.WeaponProficiencies);
            RefreshCharacterProperties();*/
        }
        public void AddClass(ClassChoice selectedClass)
        {
            Class = selectedClass;
        }
        public void AddBackground(Background background)
        {
            Background = background;
            /*ItemProficiencies = AddToListDistinct(ItemProficiencies, background.ItemProficiencies);
            Items.AddRange(background.Equipment);
            Traits = AddToListDistinct(Traits, background.Traits);


            foreach (var item in background.SkillProficiencies)
            {
                CheckSkillProficiencies(item);
            }
            MoneyPouch = background.Money;*/
        }
        public void AddInitialAbilityScores(List<AbilityScore> scores)
        {
            BaseAbilityScores = scores;
        }
        private void UpdateRaceProps()
        {
            //Race
            BaseSpeed = Race.BaseWalkingSpeed;
            FlyingSpeed = Race.BaseFlyingSpeed;
            FloatingSpeed = Race.BaseFloatingSpeed;
            SwimmingSpeed = Race.BaseSwimmingSpeed;
            ClimbingSpeed = Race.BaseClimbingSpeed;
            Traits = AddToListDistinct(Traits, Race.Traits);
            LanguageProficiencies = AddToListDistinct(LanguageProficiencies, Race.Languages);
            WeaponProficiencies = AddToListDistinct(WeaponProficiencies, Race.WeaponProficiencies);
            ItemProficiencies = AddToListDistinct(ItemProficiencies, Race.ItemProficiencies);
            foreach (var asBonus in Race.ASBonus)
            {
                switch (asBonus.AbilityScoreName)
                {
                    case SkillNameConstants.Strength:
                        Strength.RaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Intelligence:
                        Intelligence.RaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Constitution:
                        Constitution.RaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Wisdom:
                        Wisdom.RaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Charisma:
                        Charisma.RaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Dexterity:
                        Dexterity.RaceBonus = asBonus.Bonus;
                        break;
                    default:
                        break;
                }
            }

            //SubRace
            BaseSpeed = SubRace.BaseWalkingSpeed != 0 ? SubRace.BaseWalkingSpeed : BaseSpeed;
            FlyingSpeed = SubRace.BaseFlyingSpeed != 0 ? SubRace.BaseFlyingSpeed : FlyingSpeed;
            FloatingSpeed = SubRace.BaseFloatingSpeed != 0 ? SubRace.BaseFloatingSpeed : FloatingSpeed;
            SwimmingSpeed = SubRace.BaseSwimmingSpeed != 0 ? SubRace.BaseSwimmingSpeed : SubRace.BaseWalkingSpeed / 2;
            ClimbingSpeed = SubRace.BaseClimbingSpeed != 0 ? SubRace.BaseClimbingSpeed : SubRace.BaseWalkingSpeed / 2;
            Traits = AddToListDistinct(Traits, SubRace.Traits);
            LanguageProficiencies = AddToListDistinct(LanguageProficiencies, SubRace.Languages);
            WeaponProficiencies = AddToListDistinct(WeaponProficiencies, SubRace.WeaponProficiencies);
            foreach (var asBonus in SubRace.AbilityScoreBonus)
            {
                switch (asBonus.AbilityScoreName)
                {
                    case SkillNameConstants.Strength:
                        Strength.SubRaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Intelligence:
                        Intelligence.SubRaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Constitution:
                        Constitution.SubRaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Wisdom:
                        Wisdom.SubRaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Charisma:
                        Charisma.SubRaceBonus = asBonus.Bonus;
                        break;
                    case SkillNameConstants.Dexterity:
                        Dexterity.SubRaceBonus = asBonus.Bonus;
                        break;
                    default:
                        break;
                }
            }
        }
        private void UpdateClassProps()
        {
            //Class
            HitpointDice = Class.HitDice;
            ArmorProficiencies = AddToListDistinct(ArmorProficiencies, Class.ArmorProficiencies);
            WeaponProficiencies = AddToListDistinct(WeaponProficiencies, Class.WeaponProficiencies);
            ItemProficiencies = AddToListDistinct(ItemProficiencies, Class.ItemProficiencies);
            Weapons = AddToListDistinct(Weapons, Class.WeaponsChoices);
            Armor = AddToListDistinct(Armor, Class.ArmorChoices);
            foreach (var asProf in Class.AbilityScoresProficiencies)
            {
                CheckSkillProficiencies(asProf);
            }
            foreach (var skillProf in Class.SkillProficiencies)
            {
                CheckSkillProficiencies(skillProf);
            }
        }
        private void UpdateBackgroundProps()
        {
            //Background
            Items = AddToListDistinct(Items, Background.Equipment);
            ItemProficiencies = AddToListDistinct(ItemProficiencies, Background.ItemProficiencies);
            MoneyPouch = Background.Money;
            Traits = AddToListDistinct(Traits, Background.Traits);
            foreach (var skillProf in Background.SkillProficiencies)
            {
                CheckSkillProficiencies(skillProf);
            }

        }
        public void CreateCharacter()
        {
            Level = 1;
            UpdateRaceProps();
            UpdateClassProps();
            UpdateBackgroundProps();

            //Fill InitialBonuses
            foreach (var asBonus in BaseAbilityScores)
            {
                switch (asBonus.Name)
                {
                    case SkillNameConstants.Strength:
                        Strength.BaseBonus = asBonus.BaseBonus;
                        break;
                    case SkillNameConstants.Intelligence:
                        Intelligence.BaseBonus = asBonus.BaseBonus;
                        break;
                    case SkillNameConstants.Constitution:
                        Constitution.BaseBonus = asBonus.BaseBonus;
                        break;
                    case SkillNameConstants.Wisdom:
                        Wisdom.BaseBonus = asBonus.BaseBonus;
                        break;
                    case SkillNameConstants.Charisma:
                        Charisma.BaseBonus = asBonus.BaseBonus;
                        break;
                    case SkillNameConstants.Dexterity:
                        Dexterity.BaseBonus = asBonus.BaseBonus;
                        break;
                    default:
                        break;
                }
            }

            //calculate abilityscores
            Strength.Level = Strength.RaceBonus + Strength.SubRaceBonus + Strength.BaseBonus;



            RefreshCharacterProperties();
        }




        private List<T> AddToListDistinct<T>(List<T> list1, List<T> list2)
        {
            list1.AddRange(list2);
            return list1.Distinct().ToList();
        }
        private void CheckSkillProficiencies(string skill)
        {
            switch (skill)
            {
                case SkillNameConstants.Strength:
                    StrengthSave.IsProficient = true;
                    break;
                case SkillNameConstants.Dexterity:
                    DexteritySave.IsProficient = true;
                    break;
                case SkillNameConstants.Constitution:
                    ConstitutionSave.IsProficient = true;
                    break;
                case SkillNameConstants.Charisma:
                    CharismaSave.IsProficient = true;
                    break;
                case SkillNameConstants.Wisdom:
                    WisdomSave.IsProficient = true;
                    break;
                case SkillNameConstants.Intelligence:
                    IntelligenceSave.IsProficient = true;
                    break;

                case SkillNameConstants.Acrobatics:
                    Acrobatics.IsProficient = true;
                    break;
                case SkillNameConstants.AnimalHandling:
                    AnimalHandling.IsProficient = true;
                    break;
                case SkillNameConstants.Arcana:
                    Arcana.IsProficient = true;
                    break;
                case SkillNameConstants.Athletics:
                    Athletics.IsProficient = true;
                    break;
                case SkillNameConstants.Deception:
                    Deception.IsProficient = true;
                    break;
                case SkillNameConstants.History:
                    History.IsProficient = true;
                    break;
                case SkillNameConstants.Insight:
                    Insight.IsProficient = true;
                    break;
                case SkillNameConstants.Intimidation:
                    Intimidation.IsProficient = true;
                    break;
                case SkillNameConstants.Investigation:
                    Investigation.IsProficient = true;
                    break;
                case SkillNameConstants.Medicine:
                    Medicine.IsProficient = true;
                    break;
                case SkillNameConstants.Nature:
                    Nature.IsProficient = true;
                    break;
                case SkillNameConstants.Perception:
                    Perception.IsProficient = true;
                    break;
                case SkillNameConstants.Performance:
                    Performance.IsProficient = true;
                    break;
                case SkillNameConstants.Persuasion:
                    Persuasion.IsProficient = true;
                    break;
                case SkillNameConstants.Religion:
                    Religion.IsProficient = true;
                    break;
                case SkillNameConstants.SleightOfHand:
                    SleightOfHand.IsProficient = true;
                    break;
                case SkillNameConstants.Stealth:
                    Stealth.IsProficient = true;
                    break;
                case SkillNameConstants.Survival:
                    Survival.IsProficient = true;
                    break;
                default:
                    break;
            }
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
        private void RefreshCharacterProperties()
        {
            Strength.Bonus = Strength.BaseBonus + Strength.RaceBonus + Strength.SubRaceBonus;
            Dexterity.Bonus = Dexterity.BaseBonus + Dexterity.RaceBonus + Dexterity.SubRaceBonus;
            Intelligence.Bonus = Intelligence.BaseBonus + Intelligence.RaceBonus + Intelligence.SubRaceBonus;
            Constitution.Bonus = Constitution.BaseBonus + Constitution.RaceBonus + Constitution.SubRaceBonus;
            Wisdom.Bonus = Wisdom.BaseBonus + Wisdom.RaceBonus + Wisdom.SubRaceBonus;
            Charisma.Bonus = Charisma.BaseBonus + Charisma.RaceBonus + Charisma.SubRaceBonus;

            UpdateProficiencyBonus(ProficiencyBonus);
        }

        //-----------------------init------------------------
        private void LoadProperties()
        {
            Id = Guid.NewGuid();
            Weapons = new List<Weapon>();
            FillSkills();
            FillDeathSaves();
            FillAbilityScores();
            Spells = new List<Spell>();
            Cantrips = new List<Spell>();
            List<string> WeaponProficiencies = new List<string>();
            List<string> ArmorProficiencies = new List<string>();
            List<string> ItemProficiencies = new List<string>();
            List<string> LanguageProficiencies = new List<string>();
            DeathSaveSuccess = 0;
            DeathSaveFail = 0;
            Traits = new List<Trait>();
            Items = new List<Item>();
            FillMoneyPouch();
            Height = 0;
            Age = 0;
            Hair = "";
            Skin = "";
            Eyes = "";
            Background = new Background();
            Level = 0;
        }
        private void FillMoneyPouch()
        {
            MoneyPouch = new MoneyBag();
            MoneyPouch.Copper = 0;
            MoneyPouch.Silver = 0;
            MoneyPouch.Electrum = 0;
            MoneyPouch.Gold = 0;
            MoneyPouch.Platinum = 0;
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
            BagOfHoldingItems = new List<Item>();
            BagOfHoldingMoneyPouch = new MoneyBag();

            Race = new RaceChoice();
            SubRace = new SubRace();
            Class = new ClassChoice();
            SubClass = new SubClass();
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
    }
}