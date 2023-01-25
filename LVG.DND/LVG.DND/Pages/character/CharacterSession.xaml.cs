namespace LVG.DND.Pages.character;

public partial class CharacterSession : ContentPage
{
    public CharacterSession()
	{
		InitializeComponent();
		ArmorClassBtn.ButtonStat = "11";
		ArmorClassBtn.ButtonImageUrl = "shield.png";
        ArmorClassBtn.ButtonClicked = new EventHandler(ArmorClicked);
    }
    private async void ArmorClicked(object s, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}