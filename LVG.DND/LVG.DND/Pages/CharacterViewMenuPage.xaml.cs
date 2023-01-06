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
    public CharacterViewMenuPage()
	{
        LoadCharacter();
        BindingContext = character;
        InitializeComponent();
        FillCharViewStack();
    }
    private async void LoadCharacter()
    {
        character = new Character();
        character = await character.GetActiveCharacter();
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