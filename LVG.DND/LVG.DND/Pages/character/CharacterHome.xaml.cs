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
        CharacterSession SessionPage = new CharacterSession();
        await Navigation.PushAsync(SessionPage);
    }

    private async void SheetBtn_Clicked(object sender, EventArgs e)
    {
        CharacterViewMenuPage SheetPage = new CharacterViewMenuPage();
        await Navigation.PushAsync(SheetPage);
    }
}