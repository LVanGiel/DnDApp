using CommunityToolkit.Maui.Views;
using LVG.DND.Models;

namespace LVG.DND.Views.characterviews;

public partial class CharacterStorytellingView : ContentView
{
    Character _character;
	public CharacterStorytellingView()
	{
		InitializeComponent();
        LoadCharacter();
	}
    private async void LoadCharacter()
    {
        _character = new Character();
        _character = await _character.GetActiveCharacter();
    }
	private void SaveText(string title, string text)
	{
        switch (title)
        {
            case "Height":
                _character.Height = int.Parse(text);
                break;
            case "Hair":
                _character.Hair = text;
                break;
            case "Skin":
                _character.Skin = text;
                break;
            case "Eyes":
                _character.Eyes = text;
                break;
            case "Age":
                _character.Age = int.Parse(text);
                break;
            case "Personality Trait":
                _character.ChosenPersonalityTrait = text;
                break;
            case "Ideal":
                _character.ChosenIdeal = text;
                break;
            case "Flaw":
                _character.ChosenFlaw = text;
                break;
            case "Bond":
                _character.ChosenBond = text;
                break;
            case "Background":
                _character.Background.Name = text;
                break;
            default:
                break;
        }
        //_character.Save
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new StoryTellingPopup((sender as Button).Text);
        string result = (await(this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup)) as string;
        SaveText((sender as Button).Text, result);
    }
}