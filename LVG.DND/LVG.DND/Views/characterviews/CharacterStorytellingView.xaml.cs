using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterStorytellingView : ContentView
{
    Character _character;
    BaseCharacterViewModel _vm;
    public CharacterStorytellingView()
    {
        InitializeComponent();
        LoadCharacter();
	}
    private async void LoadCharacter()
    {
        _character = new Character();
        _character = await _character.GetActiveCharacter();
        backstoryTxt.Text = _character.Backstory;
    }
	private async void SaveText(string title, string text)
	{
        if (text == null || text == "")
        {
            return;
        }
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
                _character.Background = _character.Background == null ? new Background() : _character.Background;
                _character.Background.Name = text;
                break;
            default:
                break;
        }
        await _character.SaveCharacter(_character);
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new StoryTellingPopup((sender as Button).Text);
        string result = (await(this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup)) as string;
        SaveText((sender as Button).Text, result);
    }
    private async void EditBackstory_Clicked(object sender, EventArgs e)
    {
        if (backstoryTxt.IsEnabled)
        {
            await _character.SaveCharacter();
            (sender as Button).Text = "Edit";
        }
        else
        {
            (sender as Button).Text = "Save";
        }
        backstoryTxt.IsEnabled = !backstoryTxt.IsEnabled;
        
    }

    private void backstoryTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        _character.Backstory = backstoryTxt.Text;
    }
}