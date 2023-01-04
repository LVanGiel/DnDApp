﻿using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class Cantrip : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Cantrip()
        {
            Id = Guid.NewGuid();
        }
    }
}
