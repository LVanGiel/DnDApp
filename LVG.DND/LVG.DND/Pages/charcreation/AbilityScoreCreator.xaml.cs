using LVG.DND.Models;
using LVG.DND.ViewModel;
using LVG.DND.Views.charcreation.AbilityScores;
using Newtonsoft.Json;

namespace LVG.DND.Pages.charcreation;

public partial class AbilityScoreCreator : ContentPage
{
	private bool isRoll;
    CharCreateViewModel _vm;
    public AbilityScoreCreator(CharCreateViewModel vm)
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
    private async void Button_Clicked(object sender, EventArgs e)
    {
        AbilityScoreCreator AbilityScorePage = new AbilityScoreCreator(_vm);
        await Navigation.PushAsync(AbilityScorePage);
    }
}