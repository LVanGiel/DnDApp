using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models.basemodel
{
    public class Item : Base
    {
        public string Name { get; set; }
        public MoneyBag Value { get; set; }
        public decimal Weight { get; set; }
        public Item()
        {
            Id = Guid.NewGuid();
        }
    }
}
