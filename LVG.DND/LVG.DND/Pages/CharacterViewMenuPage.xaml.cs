using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views.characterviews;
using LVG.DND.Views.general;

namespace LVG.DND.Pages;

public partial class CharacterViewMenuPage : ContentPage
{
    List<ContentView> pages = new List<ContentView>();
    Character character;
    MenuConstants _menuConstants = new MenuConstants();
    public CharacterViewMenuPage()
	{
        InitializeComponent();
        LoadCharacterName();
        FillCharViewStack();
        this.Title = character.Name;

        this.Loaded += OnLoaded;
        this.Unloaded+= OnUnloaded;
    }

    private void OnUnloaded(object sender, EventArgs e)
    {
            AppShell.Current.Items.Remove(_menuConstants.flyoutItem);
    }

    private void OnLoaded(object sender, EventArgs e)
    {
        AppShell.Current.Items.Add(_menuConstants.flyoutItem);
    }
    private async void LoadCharacterName()
    {
        character = new Character();
        character = await character.GetActiveCharacter();
        //PageTitle.Text = character.Name;
    }
    private void AddImageButton(string pageName)
    {
        var imgBtn = new ImageButtonView(pageName, "dice_red4.png", CreateCommand(pageName));
        CharViewMenuStack.Add(imgBtn);
    }
    private void FillCharViewStack()
    {
        AddImageButton(CharacterViewConstants.STATS_PAGE);
        AddImageButton(CharacterViewConstants.SKILLS_ABILITYSCORES_PAGE);
        AddImageButton(CharacterViewConstants.WEAPONS_PAGE);
        AddImageButton(CharacterViewConstants.SPELLS_PAGE);
        AddImageButton(CharacterViewConstants.PROFICIENCIES_PAGE);
        AddImageButton(CharacterViewConstants.FEATURES_AND_TRAITS_PAGE);
        AddImageButton(CharacterViewConstants.INVENTORY_PAGE);
        AddImageButton(CharacterViewConstants.STORY_TELLING_PAGE);
        //AddImageButton(CharacterViewConstants.DEATHSAVES_PAGE);
    }

    private Command CreateCommand(string pageString)
    {
        var cmd = new Command(
            execute: async () =>
            {
                await Shell.Current.GoToAsync($"{nameof(CharacterViewPage)}?Page={pageString}");
            }
        );
        return cmd;
    }
}