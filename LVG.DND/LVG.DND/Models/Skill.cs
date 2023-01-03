using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.AppConstants;
using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Skill : Base
    {
        public string Name { get; set; }
        private int bonus;
        public int Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                bonus = value;
                UpdateBonusText();
            }
        }
        public string BonusText { get; set; }
        public int ClassBonus { get; set; }

        public Skill(string name, int skillBonus = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = skillBonus + ClassBonus;
            UpdateBonusText();
        }
        private void UpdateBonusText()
        {
            BonusText = (Bonus >= 0) ? $"+{Bonus}" : $"{Bonus}";
        }
    }
}
