﻿using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Trait : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Trait()
        {
            Id = Guid.NewGuid();
        }
    }
}
