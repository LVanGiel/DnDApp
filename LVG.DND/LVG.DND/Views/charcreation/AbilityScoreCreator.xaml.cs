using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.ViewModel;
using LVG.DND.Views.charcreation.AbilityScores;
using Newtonsoft.Json;

namespace LVG.DND.Views.charcreation;

public partial class AbilityScoreCreator : ContentView
{
	private bool isRoll;
	public AbilityScoreCreator()
	{
		InitializeComponent();
		isRoll = false;
        ASStack.Add(new ASManualInput(new ViewModel.AbilityScoresViewModel()));

    }
	private void RollOrNotBtn_Clicked(object sender, EventArgs e)
    {
        ASStack.Children.RemoveAt(1);

        if (isRoll) { 
			RollOrNotBtn.Text = "Manually input ability scores";
            ASStack.Add(new ASRollInput(new AbilityScoresViewModel()));
        }
		else
		{
            RollOrNotBtn.Text = "Roll for ability scores";
            ASStack.Add(new ASManualInput(new AbilityScoresViewModel()));
        }
		isRoll = !isRoll;
    }
}