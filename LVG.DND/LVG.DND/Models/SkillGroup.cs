using LVG.DND.AppConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.Models
{
    public class SkillGroup
    {
        public Skill Acrobatics { get; set; }
        public Skill AnimalHandling { get; set; }
        public Skill Arcana { get; set; }
        public Skill Athletics { get; set; }
        public Skill Deception { get; set; }
        public Skill History { get; set; }
        public Skill Insight { get; set; }
        public Skill Intimidation { get; set; }
        public Skill Investigation { get; set; }
        public Skill Medicine { get; set; }
        public Skill Nature { get; set; }
        public Skill Perception { get; set; }
        public Skill Performance { get; set; }
        public Skill Persuasion { get; set; }
        public Skill Religion { get; set; }
        public Skill SleightOfHand { get; set; }
        public Skill Stealth { get; set; }
        public Skill Survival { get; set; }

        public SkillGroup()
        {
            Acrobatics = new Skill(SkillNameConstants.Acrobatics);
            AnimalHandling = new Skill(SkillNameConstants.AnimalHandling);
            Arcana = new Skill(SkillNameConstants.Arcana);
            Athletics = new Skill(SkillNameConstants.Athletics);
            Deception = new Skill(SkillNameConstants.Deception);

            History = new Skill(SkillNameConstants.History);
            Insight = new Skill(SkillNameConstants.Insight);
            Intimidation = new Skill(SkillNameConstants.Intimidation);
            Investigation = new Skill(SkillNameConstants.Investigation);
            Medicine = new Skill(SkillNameConstants.Medicine);

            Nature = new Skill(SkillNameConstants.Nature);
            Perception = new Skill(SkillNameConstants.Perception);
            Performance = new Skill(SkillNameConstants.Performance);
            Persuasion = new Skill(SkillNameConstants.Persuasion);
            Religion = new Skill(SkillNameConstants.Religion);

            SleightOfHand = new Skill(SkillNameConstants.SleightOfHand);
            Stealth = new Skill(SkillNameConstants.Stealth);
            Survival = new Skill(SkillNameConstants.Survival);
        }
    }
}
