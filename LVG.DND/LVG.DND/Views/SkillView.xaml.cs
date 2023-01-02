using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.Views.characterviews;
using System.IO;

namespace LVG.DND.Views;

public partial class SkillView : ContentView
{
    SkillNameConstants skillConst = new SkillNameConstants();

    Streaming _stream = new Streaming();
    Skill _vm;
    public SkillView()
    {
        InitializeComponent();
        //AddAbilityScoreLevel();
    }
	public SkillView(Skill vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
		//AddAbilityScoreLevel();

    }
	private void AddAbilityScoreLevel()
	{
		bool isAbilityScore = false;
		foreach (string ASName in skillConst.AbilityScoreNames)
		{
			if (ASName == _vm.Name)
			{
				isAbilityScore = true;
            }
		}
		if (isAbilityScore)
		{
            btnAbilityScore.IsVisible= true;
            txtLevel.IsVisible= true;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button).Text == "Edit")
        {
            txtLevel.IsEnabled = true;
            (sender as Button).Text = "Confirm";
        }
        else
        {
            txtLevel.IsEnabled = false;
            (sender as Button).Text = "Edit";
            //await _stream.SaveCharacter((Parent.Parent.Parent as CharacterSkillsAndAbilitiesView)._character);
        }
    }
}