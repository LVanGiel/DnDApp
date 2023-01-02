using LVG.DND.AppConstants;
using LVG.DND.Models;

namespace LVG.DND.Views.characterviews;

public partial class CharacterSkillsAndAbilitiesView : ContentView
{
	Character _character = new Character();
	public CharacterSkillsAndAbilitiesView(Character character)
	{
		_character = character;
        InitializeComponent();
		AddAbilitiesAndSkills();

    }
	private void AddAbilitiesAndSkills()
	{
        foreach (var aS in _character.AbilityScores)
        {
			var skillView = new SkillView(aS);
            AbilityScoresStack.Add(skillView);
        }
        foreach (var skill in _character.Skills)
        {
            var skillView = new SkillView(skill);
            SkillsStack.Add(skillView);
        }
    }
}