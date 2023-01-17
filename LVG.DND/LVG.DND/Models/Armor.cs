using LVG.DND.Models.basemodel;

namespace LVG.DND.Models
{
    public class Armor : Item
    {
        public int ArmorClass { get; set; }
        public bool HasStealthDisadvantage { get; set; }
        public int StrengthRequirement { get; set; }
        public bool IsLight { get; set; }
        public bool IsMedium { get; set; }
        public bool IsHeavy { get; set; }
        public bool IsShield { get; set; }
        public Armor()
        {
            Id = Guid.NewGuid();
        }
    }
}
