﻿using LVG.DND.Models.basemodel;
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
            Id = Guid.NewGuid();
            Name = "";
        }
        public string Name { get; set; }
        public List<Bond> Bonds { get; set; }
        public List<Flaw> Flaws { get; set; }
        public List<Ideal> Ideals { get; set; }
        public List<PersonalityTrait> Personalities { get; set; }
        public string SelectedFlaw { get; set; }
        public string SelectedBond { get; set; }
        public string SelectedIdeal { get; set; }
        public string SelectedPersonalityTrait { get; set; }
        public List<string> SkillProficiencies { get; set; }
        public List<Item> Equipment { get; set; }
        public List<string> ItemProficiencies { get; set; }
        public MoneyBag Money { get; set; }
        public List<Trait> Traits { get; set; }
    }
}
