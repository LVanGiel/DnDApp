using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.Pages;
using LVG.DND.streaming;
using LVG.DND.Views;
using LVG.DND.Views.characterviews;

namespace LVG.DND;

public partial class MainPage : ContentPage
{
	Streaming streaming = new Streaming();

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnRollClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(DndDice));
	}
    private async void OnCharClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CharacterCreationPage));
    }
    private async void OnTestClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CharacterViewMenuPage));
    }
	private async void OnResetCharacterClicked(object sender, EventArgs e)
	{
		var character = new Character();
		character.Name = CharacterName.Text;
		await streaming.ChangeCharacter(character);
	}
}

