using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Weapon : Base
    {
        public string Name { get; set; }
        public Dice Dice { get; set; }
        public int AttackBonus { get; set; }
        public int AbilityScoreBonus { get; set; }
        public string DiceWithBonus { get; set; }
        public string DamageType { get; set; }
        public Weapon()
        {
            Id = Guid.NewGuid();
        }
    }
}
