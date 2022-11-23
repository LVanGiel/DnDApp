using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.ViewModel;
using LVG.DND.Views.charcreation.AbilityScores;
using Newtonsoft.Json;

namespace LVG.DND.Views.charcreation;

public partial class AbilityScoreCreator : ContentView
{
	private bool isRoll;
    AbilityScoresViewModel _vm;
    public AbilityScoreCreator(AbilityScoresViewModel vm)
	{
		InitializeComponent();
		isRoll = false;
        _vm = vm;
        ASStack.Add(new ASManualInput(_vm));
    }
    public AbilityScoreCreator()
    {
        InitializeComponent();
        isRoll = false;
        ASStack.Add(new ASManualInput(_vm));
    }
    private void RollOrNotBtn_Clicked(object sender, EventArgs e)
    {
        ASStack.Children.RemoveAt(1);

        if (isRoll) { 
			RollOrNotBtn.Text = "Manually input ability scores";
            ASStack.Add(new ASRollInput(_vm));
        }
		else
		{
            RollOrNotBtn.Text = "Roll for ability scores";
            ASStack.Add(new ASManualInput(_vm));
        }
		isRoll = !isRoll;
    }
}