using LVG.DND.Models;
using LVG.DND.ViewModel;
using CommunityToolkit.Maui.Views;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASRollInput : ContentView
{
    AbilityScoresViewModel _vm = new AbilityScoresViewModel();
    List<string> scores = new List<string>();
    public ASRollInput(AbilityScoresViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
        _vm.DiceScores = new List<int>();
    }
    private async void RollBtn_Clicked(object sender, EventArgs e)
    {
        _vm.DiceScores = new List<int>();
        int rollCount = 6;
        for (int i = 0; i < rollCount; i++)
        {
            await DisplayDicePopup();
        }
        DiceRollCollection.ItemsSource = scores;
    }
    private async Task DisplayDicePopup()
    {
        int originalCount = _vm.DiceScores.Count;
        while (_vm.DiceScores.Count <= originalCount)
        {
            var popup = new DicePopup(6, true);
            var popupResult = await (this.Parent.Parent.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup);
            if (popupResult is int intResult)
            {
                _vm.DiceScores.Add(intResult);
                scores.Add(intResult.ToString());
            }
        }
    }
}