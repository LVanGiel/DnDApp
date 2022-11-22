using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class DiceView : ContentView
{
    public Dice dice;
    public DiceView()
    {
        InitializeComponent();
        dice = new Dice();
        dice.ChangeSize(20);
        BindingContext = dice;
    }
    public DiceView(int diceSize)
    {
        InitializeComponent();
        dice = new Dice();
        dice.ChangeSize(diceSize);
        BindingContext = dice;
    }
    private async void btnDice_Clicked(object sender, EventArgs e)
    {
        Button btnDice = sender as Button;

        await dice.RollDice(btnDice.ZIndex);
        await Task.Delay(500);

    }
}