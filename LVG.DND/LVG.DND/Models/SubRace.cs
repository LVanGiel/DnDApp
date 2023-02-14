using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class SubRace : Base
    {
        public string Name { get; set; }
        public string Backstory { get; set; }
        public List<RaceAbilityScoreBonus> AbilityScoreBonus { get; set; }
        public List<Trait> Traits { get; set; }
        public List<string> WeaponProficiencies { get; set; }
        public List<Spell> SpellsAndCantrips { get; set; }
        public List<string> Languages { get; set; }
        public int BaseWalkingSpeed { get; set; }
    }
}
