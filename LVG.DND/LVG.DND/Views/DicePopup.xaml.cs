using CommunityToolkit.Maui.Views;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class DicePopup : Popup
{
    public Dice dice;
    public bool needsReturn;
    public DicePopup()
	{
		InitializeComponent();
        dice = new Dice();
        dice.ChangeSize(20);
        BindingContext = dice;
    }
	public DicePopup(int diceSize, bool returnValue = false)
	{
        InitializeComponent();
        dice = new Dice();
        dice.ChangeSize(diceSize);
        BindingContext = dice;
        needsReturn = returnValue;
    }
    private async void btnDice_Clicked(object sender, EventArgs e)
	{
        Button btnDice = sender as Button;

        await dice.RollDice(btnDice.ZIndex);
        await Task.Delay(500);

        if (needsReturn)
        {
            this.Close(dice.Number);
        }
        
    }


}