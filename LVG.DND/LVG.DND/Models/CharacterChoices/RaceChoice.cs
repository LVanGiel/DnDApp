using LVG.DND.Models.basemodel;

namespace LVG.DND.Models.CharacterChoices
{
    public class RaceChoice : Base
    {
        public string Name { get; set; }
        public string AgeInfo { get; set; }
        public string SizeInfo { get; set; }
        public string AlignmentInfo { get; set; }
        public int BaseWalkingSpeed { get; set; }
        public int BaseFlyingSpeed { get; set; }
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
    }
}
