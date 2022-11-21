using LVG.DND.Models;
using LVG.DND.ViewModel;
using CommunityToolkit.Maui.Views;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASRollInput : ContentView
{
    AbilityScoresViewModel _vm = new AbilityScoresViewModel();
    List<int> diceScores = new List<int>();
    public ASRollInput(AbilityScoresViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
    private async void RollBtn_Clicked(object sender, EventArgs e)
    {
        diceScores = new List<int>();
        int rollCount = 6;
        for (int i = 0; i < rollCount; i++)
        {
            await DisplayDicePopup();
        }
    }
    private async Task DisplayDicePopup()
    {
        int originalCount = diceScores.Count;
        while (diceScores.Count <= originalCount)
        {
            var popup = new DicePopup(6, true);
            var popupResult = await (this.Parent.Parent.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup);
            if (popupResult is int intResult)
            {
                diceScores.Add(intResult);
            }
        }
    }
}