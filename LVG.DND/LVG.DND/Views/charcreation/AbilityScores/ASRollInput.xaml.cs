using LVG.DND.Models;
using LVG.DND.ViewModel;
using CommunityToolkit.Maui.Views;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASRollInput : ContentView
{
    AbilityScoresViewModel _vm = new AbilityScoresViewModel();
    List<string> scores = new List<string>();
    List<string> selectedScores = new List<string>();
    int rollCounter = 0;
    List<string> abilityScoresStrings = new List<string>();
    public ASRollInput(AbilityScoresViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
        _vm.DiceScores = new List<int>();
        FillAbilityScores();
    }
    private void FillAbilityScores()
    {
        AbilitySCoresStack.Add(AddAS("Strength"));
        AbilitySCoresStack.Add(AddAS("Dexterity"));
        AbilitySCoresStack.Add(AddAS("Constitution"));
        AbilitySCoresStack.Add(AddAS("Intelligence"));
        AbilitySCoresStack.Add(AddAS("Wisdom"));
        AbilitySCoresStack.Add(AddAS("Charisma"));
    }
    private HorizontalStackLayout AddAS(string ability)
    {
        var abilityBtn = new Button();
        abilityBtn.Text = ability;
        abilityBtn.Clicked += new EventHandler(AbilityBtn_Clicked);

        var abilityLabel = new Label();
        abilityLabel.SetBinding(Label.TextProperty, "Character." + ability);

        var abilityStack = new HorizontalStackLayout();
        abilityStack.Add(abilityBtn);
        abilityStack.Add(abilityLabel);
        abilityStack.HorizontalOptions = LayoutOptions.Center;

        return abilityStack;
    }
    private async void RollBtn_Clicked(object sender, EventArgs e)
    {
        _vm.DiceScores = new List<int>();

        await DisplayDicePopup();

        DiceRollCollection.ItemsSource = scores;
    }
    private async Task DisplayDicePopup()
    {
        int originalCount = _vm.DiceScores.Count;
        scores = new List<string>();
        selectedScores = new List<string>();
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
        DiceRollCollectionSelected.ItemsSource = selectedScores;
        DiceRollCollection.ItemsSource = scores;
        rollCounter++;
    }

    private void AbilityBtn_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var parent = new HorizontalStackLayout();
        var neighbour = new Label();
        var selectedScore = int.Parse(AbilityScoreCollection.SelectedItem.ToString());
        switch (btn.Text)
        {
            case "Strength":
                _vm.Character.Strength.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            case "Dexterity":
                _vm.Character.Dexterity.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            case "Constitution":
                _vm.Character.Constitution.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            case "Intelligence":
                _vm.Character.Intelligence.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            case "Wisdom":
                _vm.Character.Wisdom.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            case "Charisma":
                _vm.Character.Charisma.Level = selectedScore;
                parent = btn.Parent as HorizontalStackLayout;
                neighbour = parent.Children[1] as Label;
                neighbour.Text = selectedScore.ToString();
                break;
            default:
                break;
        }
        abilityScoresStrings.Remove(selectedScore.ToString());
        AbilityScoreCollection.ItemsSource = new List<string>();
        AbilityScoreCollection.ItemsSource = abilityScoresStrings;

    }

    private async void submitDiceBtn_Clicked(object sender, EventArgs e)
    {
        var diceSelection = selectedScores;

        int total = 0;
        foreach (var diceNumber in diceSelection)
        {
            total += int.Parse(diceNumber.ToString());
        }

        scores = new List<string>();
        selectedScores = new List<string>();
        _vm.DiceScores = new List<int>();
        DiceRollCollection.ItemsSource = scores;

        if (abilityScoresStrings.Count() < 6)
        {
            abilityScoresStrings.Add(total.ToString());
            AbilityScoreCollection.ItemsSource = new List<string>();
            AbilityScoreCollection.ItemsSource = abilityScoresStrings;

            AbilityScoreCollection.SelectedItems.Clear();
            if (abilityScoresStrings.Count() < 6)
            {
                await DisplayDicePopup();
            }
        }
    }

    private void DiceRollCollection_SelectionChanged(Object sender, SelectionChangedEventArgs e)
    {
        if (DiceRollCollection.SelectedItem == null)
        {
            return;
        }

        if (selectedScores.Count >= 3)
        {
            scores.Add(selectedScores[0]);
            selectedScores.RemoveAt(0);
        }

        selectedScores.Add(DiceRollCollection.SelectedItem.ToString());

        scores.Remove(DiceRollCollection.SelectedItem.ToString());

        DiceRollCollection.SelectedItem = null;

        DiceRollCollectionSelected.ItemsSource = new List<string>();
        DiceRollCollection.ItemsSource = new List<string>();

        DiceRollCollectionSelected.ItemsSource = selectedScores;
        DiceRollCollection.ItemsSource = scores;
    }
}