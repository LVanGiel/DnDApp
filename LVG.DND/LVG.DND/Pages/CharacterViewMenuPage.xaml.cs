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
        InitializeComponent();
        LoadCharacterName();
        FillCharViewStack();
        this.Title = character.Name;

        this.Loaded += OnLoaded;
    }
    private void OnLoaded(object sender, EventArgs e)
    {
        var flyoutItem = new FlyoutItem()
        {
            Title = "Test",
            Route = "Test",
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            Items =
            {
                new ShellContent
                {
                    Title="Test1",
                    ContentTemplate = new DataTemplate(typeof(DndDice))
                },
                new ShellContent
                {
                    Title="Test2",
                    ContentTemplate = new DataTemplate(typeof(DndDice))
                }
            }
        };
        AppShell.Current.Items.Add(flyoutItem);
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