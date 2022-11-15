using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Background : Base
    {
        public Background()
        {

        }
        public List<Bond> Bonds { get; set; }
        public List<Flaw> Flaws { get; set; }
        public List<Ideal> Ideals { get; set; }
        public List<PersonalityTrait> Personalities { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
        public List<Item> Equipment { get; set; }
        public List<Item> ItemProficiencies { get; set; }
        public MoneyBag Money { get; set; }
        public List<Traits> Traits { get; set; }
    }
}
