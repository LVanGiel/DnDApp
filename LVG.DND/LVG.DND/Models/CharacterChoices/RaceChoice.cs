using LVG.DND.Models.basemodel;

namespace LVG.DND.Models.CharacterChoices
{
    public class RaceChoice : Base
    {
        public string Name { get; set; }
        public int BaseWalkingSpeed { get; set; }
        public int BaseFlyingSpeed { get; set; }
        public int BaseFloatingSpeed { get; set; }
        public int BaseSwimmingSpeed { get; set; }
        public int BaseClimbingSpeed { get; set; }
        public List<Trait> Traits { get; set; }
        public List<string> Languages { get; set; }
        public string Backstory { get; set; }
        public List<string> WeaponProficiencies { get; set; }
        public List<string> ItemProficiencies { get; set; }
        public List<RaceAbilityScoreBonus> ASBonus { get; set; }

        public RaceChoice()
        {
            Id = Guid.NewGuid();
        }
        public void ConvertRace(Race race)
        {
            Name = race.Name;
            BaseWalkingSpeed = race.BaseWalkingSpeed;
            BaseFlyingSpeed = race.BaseFlyingSpeed;
            BaseFloatingSpeed = race.BaseFloatingSpeed;
            BaseSwimmingSpeed = race.BaseSwimmingSpeed;
            BaseClimbingSpeed = race.BaseClimbingSpeed;
            WeaponProficiencies = race.WeaponProficiencies;
            ItemProficiencies = race.ItemProficiencies;
            Traits = race.Traits;
            Languages = race.Languages;
            ASBonus = race.ASBonus;
        }
    }
}
