using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    internal class Weapon
    {
        public string Name { get; set; }
        public Dice DamageDice { get; set; }
        public int DamageBonus { get; set; }
        public string DamageType { get; set; }
        public Weapon()
        {

        }
    }
}
