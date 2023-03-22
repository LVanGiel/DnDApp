using LVG.DND.Models;
using LVG.DND.Pages.character;
using LVG.DND.Pages.charcreation;
using LVG.DND.streaming;
using LVG.DND.ViewModel;

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
        var streaming = new Streaming();
        streaming.SaveJokmir();
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
        character.Name = (((sender as Button).Parent as Grid).Children[0] as Label).Text;
        await character.ChangeCharacter(character);
        await Shell.Current.GoToAsync(nameof(CharacterHome));
    }

    private async void AddCharacterBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RaceSelector));
    }
}