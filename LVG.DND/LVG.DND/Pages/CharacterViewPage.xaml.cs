using CommunityToolkit.Maui.Views;
using LVG.DND.Views;
using LVG.DND.Views.general;
using Microsoft.Maui.Controls;

namespace LVG.DND.Pages;

public partial class CharacterViewPage : ContentPage
{
	public CharacterViewPage()
	{
		InitializeComponent();
        var cmd = new Command(
        execute: () =>
        {
            Test();
        }
    );
        ImageButtonView imgBtnView = new ImageButtonView("Test", "dice_red4.png", cmd);
        CharViewStack.Add(imgBtnView);
    }
	private void Test()
	{
        var valueList = new List<int>();
        valueList.Add(4);
        var popup = new DicePopup(valueList);

        this.ShowPopupAsync(popup);
    }
}