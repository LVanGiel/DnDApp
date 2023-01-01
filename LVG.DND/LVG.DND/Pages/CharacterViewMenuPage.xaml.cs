using LVG.DND.AppConstants;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views.characterviews;
using LVG.DND.Views.general;

namespace LVG.DND.Pages;

public partial class CharacterViewMenuPage : ContentPage
{
    List<ContentView> pages = new List<ContentView>();
    public CharacterViewMenuPage()
	{
		InitializeComponent();
        FillCharViewStack();
    }
    private void AddImageButton(ContentView page, string pageName)
    {
        var imgBtn = new ImageButtonView(pageName, "dice_red4.png", CreateCommand(pageName));
        CharViewMenuStack.Add(imgBtn);
    }
    private void FillCharViewStack()
    {
        AddImageButton(new CharacterStatsView(new CharacterStatsViewModel()), CharacterViewConstants.STATS_PAGE);
        AddImageButton(new CharacterSkillsAndAbilitiesView(), CharacterViewConstants.SKILLS_ABILITYSCORES_PAGE);
        AddImageButton(new CharacterFeaturesAndTraitsView(), CharacterViewConstants.FEATURES_AND_TRAITS_PAGE);
        AddImageButton(new CharacterWeaponsView(), CharacterViewConstants.WEAPONS_PAGE);
        AddImageButton(new CharacterSpellsView(), CharacterViewConstants.SPELLS_PAGE);
        AddImageButton(new CharacterInventoryView(), CharacterViewConstants.INVENTORY_PAGE);
        AddImageButton(new CharacterProficienciesView(), CharacterViewConstants.PROFICIENCIES_PAGE);
        AddImageButton(new CharacterStorytellingView(), CharacterViewConstants.STORY_TELLING_PAGE);
        AddImageButton(new CharacterDeathSavesView(), CharacterViewConstants.DEATHSAVES_PAGE);
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