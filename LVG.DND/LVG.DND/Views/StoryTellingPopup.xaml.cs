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
        LoadDescription(title);
    }
    private async void LoadDescription(string title)
    {
        Titletxt.Text = title;
        await AddCharacter();
        string result = "";
        switch (title)
        {
            case "Height":
                result= _character.Height.ToString();
                break;
            case "Hair":
                result = _character.Hair;
                break;
            case "Skin":
                result = _character.Skin;
                break;
            case "Eyes":
                result = _character.Eyes;
                break;
            case "Age":
                result = _character.Age.ToString();
                break;
            case "Personality Trait":
                result = _character.Background.SelectedPersonalityTrait;
                break;
            case "Ideal":
                result = _character.Background.SelectedIdeal;
                break;
            case "Flaw":
                result = _character.Background.SelectedFlaw;
                break;
            case "Bond":
                result = _character.Background.SelectedBond;
                break;
            case "Background":
                _character.Background = _character.Background == null ? new Background() : _character.Background;
                result = _character.Background.Name;
                break;
            default:
                result = "";
                break;
        }
        Contenttxt.Text = result;
    }
    private async Task AddCharacter()
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