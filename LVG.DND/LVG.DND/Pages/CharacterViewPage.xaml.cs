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
        FillCharViewStack();
    }
	private void Test()
	{
        var valueList = new List<int>();
        valueList.Add(4);
        var popup = new DicePopup(valueList);

        this.ShowPopupAsync(popup);
    }

    private void FillCharViewStack()
    {
        var cmd = new Command(
            execute: () =>
            {
                Test();
            }
        );
        var imgBtnList = new List<ImageButtonView>();

        imgBtnList.Add(new ImageButtonView("Stats", "dice_red20.png", cmd));
        imgBtnList.Add(new ImageButtonView("Skills & Abilityscores", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Proficiencies", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Inventory", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Weapons", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Spells", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Features & traits", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Storytelling", "dice_red4.png", cmd));
        imgBtnList.Add(new ImageButtonView("Death saves", "dice_red4.png", cmd));

        foreach (var imgBtn in imgBtnList)
        {
            CharViewStack.Add(imgBtn);
        }
    }
}