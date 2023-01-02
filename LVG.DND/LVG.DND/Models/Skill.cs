using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Skill : Base
    {
        public string Name { get; set; }
        public int Bonus { get; set; }
        public Skill()
        {
            Id = Guid.NewGuid();
        }
        public Skill(string name, int bonus)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = bonus;
        }
    }
}
