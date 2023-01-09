using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class StoryTellingPopup : Popup
{
    Character _character;
	public StoryTellingPopup(string title)
	{
		InitializeComponent();
        Titletxt.Text = title;
        AddCharacter();
        LoadDescription(title);
    }
    private string LoadDescription(string title)
    {
        switch (title)
        {
            case "Height":
                return _character.Height.ToString();
            case "Hair":
                return _character.Hair;
            case "Skin":
                return _character.Skin;
            case "Eyes":
                return _character.Eyes;
            case "Age":
                return _character.Age.ToString();
            case "Personality Trait":
                return _character.ChosenPersonalityTrait;
            case "Ideal":
                return _character.ChosenIdeal;
            case "Flaw":
                return _character.ChosenFlaw;
            case "Bond":
                return _character.ChosenBond;
            case "Background":
                return _character.Background.Name;
            default:
                return "";
        }
    }
    private async void AddCharacter()
    {
        _character = new Character();
        _character = await _character.GetActiveCharacter();
    }
    private void EditButton_Clicked(object sender, EventArgs e)
    {
        if (Contenttxt.IsEnabled)
        {
            (sender as Button).Text = "Edit";
        }
        else
        {
            (sender as Button).Text = "OK";
            Savebtn.IsVisible = true;
        }
        Contenttxt.IsEnabled = !Contenttxt.IsEnabled;
    }
    private void SaveButton_Clicked(Object sender, EventArgs e)
    {
        this.Close(Contenttxt.Text);
    }
}