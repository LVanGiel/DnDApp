using CommunityToolkit.Maui.Views;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class DicePopup : Popup
{
    public bool needsReturn;
    List<int> _diceSizes;
    List<int> _diceResults;
    public DicePopup()
	{
		InitializeComponent();
    }
	public DicePopup(List<int> diceSizes, bool returnValue = false)
	{
        InitializeComponent();
        needsReturn = returnValue;
        _diceSizes = diceSizes;
        _diceResults = new List<int>();
        GenerateDice();
        AddButton();
    }

    private void GenerateDice()
    {
        for (int i = 0; i < _diceSizes.Count; i++)
        {
            var diceView = new DiceView(_diceSizes[i]);
            DicePopupStack.Add(diceView);
        }
    }
    private void AddButton()
    {
        var btnNextRoll = new Button();
        btnNextRoll.Clicked += new EventHandler(NextRollBtn_Clicked);
        btnNextRoll.Text = "Done rolling";

        DicePopupPrimairyStack.Add(btnNextRoll);
    }

    private void NextRollBtn_Clicked(object sender, EventArgs e)
    {
        foreach (DiceView diceview in DicePopupStack.Children.ToList())
        {
            _diceResults.Add(diceview.dice.Number);
        }
        
        this.Close(_diceResults);
    }
}