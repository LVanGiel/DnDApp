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
        //baseBonus
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
                UpdateBonus();
            }
        }
        public int TotalBonus { get; set; }
        public string BonusText { get; set; }
        private int classBonus;
        public int ClassBonus
        {
            get
            {
                return classBonus;
            }
            set
            {
                classBonus = value;
                UpdateBonus();
            }
        }
        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get
            {
                return proficiencyBonus;
            }
            set
            {
                proficiencyBonus = value;
                UpdateBonus();
            }
        }

        public bool IsProficient { get; set; }

        public Skill(string name, int skillBonus = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = skillBonus;
            UpdateBonus();
        }
        private void UpdateBonus()
        {
            TotalBonus = Bonus + ClassBonus + ProficiencyBonus;
            BonusText = (TotalBonus >= 0) ? $"+{TotalBonus}" : $"{TotalBonus}";
            if (ProficiencyBonus > 0)
            {
                IsProficient = true;
            }
            else
            {
                IsProficient = false;
            }
        }
    }
}
