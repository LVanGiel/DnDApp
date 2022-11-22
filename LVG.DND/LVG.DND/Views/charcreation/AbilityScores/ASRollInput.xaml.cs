using LVG.DND.Models;
using LVG.DND.ViewModel;
using CommunityToolkit.Maui.Views;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASRollInput : ContentView
{
    AbilityScoresViewModel _vm = new AbilityScoresViewModel();
    List<string> scores = new List<string>();
    int rollCounter = 0;
    List<string> abilityScoresStrings = new List<string>();
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
        int rollCountGoal = 6;

        await DisplayDicePopup();

        DiceRollCollection.ItemsSource = scores;
    }
    private async Task DisplayDicePopup()
    {
        int originalCount = _vm.DiceScores.Count;
        scores = new List<string>();
        var dicelist = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            dicelist.Add(6);
        }
        var popup = new DicePopup(dicelist, true);
        var page = this.Parent.Parent.Parent.Parent.Parent as ContentPage;
        var popupResult = await page.ShowPopupAsync(popup);
        if (popupResult is List<int> intResult)
        {
            foreach (var result in intResult)
            {
                _vm.DiceScores.Add(result);
                scores.Add(result.ToString());
            }
        }
        DiceRollCollection.ItemsSource = scores;
        rollCounter++;
    }

    private void submitDiceBtn_Clicked(object sender, EventArgs e)
    {
        var diceSelection = DiceRollCollection.SelectedItems;

        int total = 0;
        foreach (var diceNumber in diceSelection)
        {
            total += int.Parse(diceNumber.ToString());
        }

        scores = new List<string>();
        _vm.DiceScores = new List<int>();
        DiceRollCollection.ItemsSource = scores;

        abilityScoresStrings.Add(total.ToString());
        AbilityScoreCollection.ItemsSource = new List<string>();
        AbilityScoreCollection.ItemsSource = abilityScoresStrings;

        AbilityScoreCollection.SelectedItems.Clear();
    }
}