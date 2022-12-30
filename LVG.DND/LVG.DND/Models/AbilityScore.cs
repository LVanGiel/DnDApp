using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class AbilityScore : Base
    {
        public int Amount { get; set; }
        public string Ability { get; set; }
        public AbilityScore()
        {
            Id = Guid.NewGuid();
        }
        public AbilityScore(string ability, int amount)
        {
            Amount = amount;
            Ability = ability;
            Id = Guid.NewGuid();
        }
    }
}
