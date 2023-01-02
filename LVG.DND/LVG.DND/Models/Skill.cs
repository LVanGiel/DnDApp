using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models.basemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class Skill : ObservableObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Bonus { get; set; }
        public string BonusText { get; set; }
        public int Level { get; set; }
        public Skill()
        {
        }
        public Skill(string name, int abilityScoreLevel = 0, bool isAbilityScore = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = (abilityScoreLevel - 10) / 2;
            BonusText = (Bonus >= 0)? $"+{Bonus}": $"{Bonus}";
            if (isAbilityScore)
            {
                Level = abilityScoreLevel;
            }
        }
    }
}
