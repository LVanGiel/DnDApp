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
        public int Bonus { get; set; }
        public string BonusText { get; set; }
        public string AbilityScoreName { get; set; }

        private SkillNameConstants skillName = new SkillNameConstants();
        public Skill(string name, int skillBonus = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bonus = skillBonus;
            BonusText = (Bonus >= 0)? $"+{Bonus}": $"{Bonus}";
            ChooseAbilityScore();
        }
        private void ChooseAbilityScore()
        {
            if (Name == skillName.SkillNames[3])
            {
                AbilityScoreName = skillName.AbilityScoreNames[0];
                return;
            }
            if (Name == skillName.SkillNames[0] || Name == skillName.SkillNames[15] || Name == skillName.SkillNames[16])
            {
                AbilityScoreName = skillName.AbilityScoreNames[1];
                return;
            }
            if (Name == skillName.SkillNames[2] || Name == skillName.SkillNames[5] || Name == skillName.SkillNames[8] || Name == skillName.SkillNames[10] || Name == skillName.SkillNames[14])
            {
                AbilityScoreName = skillName.AbilityScoreNames[3];
                return;
            }
            if (Name == skillName.SkillNames[1] || Name == skillName.SkillNames[6] || Name == skillName.SkillNames[9] || Name == skillName.SkillNames[11] || Name == skillName.SkillNames[17])
            {
                AbilityScoreName = skillName.AbilityScoreNames[4];
                return;
            }
            if (Name == skillName.SkillNames[4] || Name == skillName.SkillNames[7] || Name == skillName.SkillNames[12] || Name == skillName.SkillNames[13])
            {
                AbilityScoreName = skillName.AbilityScoreNames[5];
                return;
            }
        }
    }
}
