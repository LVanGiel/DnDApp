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
        RollDice();
    }
    public DiceView(int diceSize)
    {
        InitializeComponent();
        dice = new Dice();
        dice.ChangeSize(diceSize);
        BindingContext = dice;
        RollDice();
    }
    public async void RollDice()
    {
        await dice.RollDice(btnRollDice.ZIndex);
    }
    private void btnDice_Clicked(object sender, EventArgs e)
    {
        RollDice();
    }
}