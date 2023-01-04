using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class Spell : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Spell()
        {
            Id = Guid.NewGuid();
        }
    }
}
