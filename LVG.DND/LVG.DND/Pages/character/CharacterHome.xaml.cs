using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Pages.character;

public partial class CharacterHome : ContentPage
{
	public CharacterHome()
	{
		InitializeComponent();
	}

    private async void SessionBtn_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(CharacterSession), typeof(CharacterSession));
        var activeChar = await (new Character()).GetActiveCharacter();
        var vm = new BaseCharacterViewModel(activeChar);
        CharacterSession SessionPage = new CharacterSession(vm);
        await Navigation.PushAsync(SessionPage);
    }

    private async void SheetBtn_Clicked(object sender, EventArgs e)
    {
        CharacterViewMenuPage SheetPage = new CharacterViewMenuPage();
        await Navigation.PushAsync(SheetPage);
    }
    private async void LevelBtn_Clicked(object sender, EventArgs e)
    {
        CharacterViewMenuPage SheetPage = new CharacterViewMenuPage();
        await Navigation.PushAsync(SheetPage);
    }
}