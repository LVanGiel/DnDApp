using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views;

public partial class TitleBar : ContentView
{
	Character character;
	public TitleBar()
	{
		InitializeComponent();
        LoadCharacter();
    }
    public void UpdateCharacter(Character _character)
    {
        character = _character;
        SetCharacterProperties();
    }
    private async void LoadCharacter()
	{
		character = new Character();
        character = await character.GetActiveCharacter();
        SetCharacterProperties();
    }
    private void SetCharacterProperties()
    {
        lblName.Text = character.Name;
        if (character.Class != null && character.Class != "")
        {
            lblClass.Text = character.Class;
        }
        if (character.Race != null && character.Race != "")
        {
            lblRace.Text = character.Race;
        }
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}