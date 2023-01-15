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
        public List<RaceAbilityScoreBonus> AbilityScoreBonus { get; set; }
        public int MaxAge { get; set; }
        public int Height { get; set; }
    }
}
