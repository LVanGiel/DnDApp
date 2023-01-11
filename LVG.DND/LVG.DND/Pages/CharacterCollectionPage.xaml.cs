using LVG.DND.Models;
using LVG.DND.ViewModel;
using System.Collections.ObjectModel;

namespace LVG.DND.Pages;

public partial class CharacterCollectionPage : ContentPage
{
    CharacterCollectionPageViewModel _vm;
    public CharacterCollectionPage()
	{
        _vm = new CharacterCollectionPageViewModel();
        BindingContext = _vm;
        InitializeComponent();
        init();
    }
	private async void init()
	{
		Character character = new Character();
		_vm.Characters = await character.GetAllCharacter();
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {

    }
    private async void SetButton_Clicked(object sender, EventArgs e)
    {
        Character character = new Character();
        character.Name = (((sender as Button).Parent as VerticalStackLayout).Children[1] as Label).Text;
        await character.ChangeCharacter(character);
    }
}