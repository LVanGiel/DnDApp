using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class ClassLevel : Base
    {
        public int Level { get; set; }
        public string SpecialSkillDice { get; set; }
        public List<string> SpellChoices { get; set; }
        public int SpellsToLearn { get; set; }
        public List<string> ClassSpells { get; set; }
        public List<string> SpellChoicesLevel1 { get; set; }
        public List<string> SpellChoicesLevel2 { get; set; }
        public List<string> SpellChoicesLevel3 { get; set; }
        public List<string> SpellChoicesLevel4 { get; set; }
        public List<string> SpellChoicesLevel5 { get; set; }
        public List<string> SpellChoicesLevel6 { get; set; }
        public List<string> SpellChoicesLevel7 { get; set; }
        public List<string> SpellChoicesLevel8 { get; set; }
        public List<string> SpellChoicesLevel9 { get; set; }

        public int SpellSlotsLevel1 { get; set; }
        public int SpellSlotsLevel2 { get; set; }
        public int SpellSlotsLevel3 { get; set; }
        public int SpellSlotsLevel4 { get; set; }
        public int SpellSlotsLevel5 { get; set; }
        public int SpellSlotsLevel6 { get; set; }
        public int SpellSlotsLevel7 { get; set; }
        public int SpellSlotsLevel8 { get; set; }
        public int SpellSlotsLevel9 { get; set; }

        public ClassLevel()
        {
            Id = Guid.NewGuid();
        }
    }
}
