using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class Spell : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpellLevel { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public Spell()
        {
            Id = Guid.NewGuid();
        }
    }
}
