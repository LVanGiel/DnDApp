using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Weapon : Item
    {
        public int DiceSize { get; set; }
        public int DiceCount { get; set; }
        public int AttackBonus { get; set; }
        public int AbilityScoreBonus { get; set; }
        public string DiceWithBonus { get; set; }
        public string DamageType { get; set; }
        public string ExtraInfo { get; set; }
        public bool IsMartial { get; set; }
        public bool IsRanged { get; set; }
        public string AmmoType { get; set; }
        public bool IsTwohanded { get; set; }
        public bool IsThrown { get; set; }
        public string Range { get; set; }
        public bool HasReach { get; set; }
        public bool IsVersatile { get; set; }
        public int VersatileDice { get; set; }
        public Weapon()
        {
            Id = Guid.NewGuid();
        }
    }
}
