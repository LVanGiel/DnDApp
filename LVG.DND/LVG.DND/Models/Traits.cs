using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Traits : Base
    {
        public Traits()
        {
            Id = Guid.NewGuid();
        }
    }
}
