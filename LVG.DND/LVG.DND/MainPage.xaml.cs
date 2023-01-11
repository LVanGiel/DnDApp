using CommunityToolkit.Maui.Views;
using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.Pages;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;
using LVG.DND.Views.characterviews;

namespace LVG.DND;

public partial class MainPage : ContentPage
{
	Streaming streaming = new Streaming();
    MenuConstants _menuConstants = new MenuConstants();

    public MainPage()
	{
		InitializeComponent();
        streaming.SaveJokmir();
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
    private async void OnUploadCharacterClicked(object sender, EventArgs e)
    {
        //var options = new PickOptions();
        //try
        //{
        //    var result = await FilePicker.Default.PickAsync(options);
        //    if (result != null)
        //    {
        //        using var stream = await result.OpenReadAsync();
        //        var image = ImageSource.FromStream(() => stream);
        //    }

        //    // result;
        //}
        //catch (Exception ex)
        //{
        //    // The user canceled or something went wrong
        //}
        await Shell.Current.GoToAsync(nameof(CharacterCollectionPage));
    }
}

