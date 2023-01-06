using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;
using System.Xml.Linq;

namespace LVG.DND.Pages;

[QueryProperty(nameof(Page), nameof(Page))]
public partial class CharacterViewPage : ContentPage
{
    CharacterViewConstants _constants = new CharacterViewConstants();
    string page = "";
    Character character;
    public string Page { get { return page; } set
        {
            page = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            AddToStack();
        } }
    public ContentView SelectedPage { get; set; }

    public int MyProperty { get; set; }
    public CharacterViewPage()
	{
        InitializeComponent();
        LoadCharacterName();
        this.Title = character.Name;
    }
    private async void LoadCharacterName()
    {
        character = new Character();
        character = await character.GetActiveCharacter();
    }
    private async void AddToStack()
    {
        SelectedPage = await _constants.GetCorrectPage(Page);
        CharViewStack.Add(SelectedPage);
    }

}