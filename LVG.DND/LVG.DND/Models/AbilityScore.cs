using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class AbilityScore : Base
    {
        private int level;
        public string Name { get; set; }
        public int RaceBonus { get; set; }
        public int Bonus { get; set; }
        public string BonusText { get; set; }
        public int Level {
            get
            {
                return level;
            }
            set
            {
                level = value;
                UpdateLevel(value);
            } 
        }
        public bool IsLevelEditable { get; set; }
        public AbilityScore(string name, int abilityScoreLevel = 0, bool isAbilityScore = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = (abilityScoreLevel - 10) / 2;
            BonusText = (Bonus >= 0)? $"+{Bonus}": $"{Bonus}";
            if (isAbilityScore)
            {
                Level = abilityScoreLevel;
            }
            IsLevelEditable = false;
        }
        private void UpdateLevel(int levelValue)
        {
            Bonus = (int)Math.Floor(decimal.Parse((levelValue - 10).ToString()) / 2);
            BonusText = (Bonus >= 0) ? $"+{Bonus}" : $"{Bonus}";
        }
    }
}
