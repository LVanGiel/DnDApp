using CommunityToolkit.Maui.Views;
using LVG.DND.Pages.characterViews;
using LVG.DND.ViewModel;
using LVG.DND.Views;
using LVG.DND.Views.general;
using Microsoft.Maui.Controls;

namespace LVG.DND.Pages;

public partial class CharacterViewPage : ContentPage
{
    List<ContentPage> pages = new List<ContentPage>();
	public CharacterViewPage()
	{
		InitializeComponent();
        FillPageList();
        AddRouting();
        FillCharViewStack();
    }
    private void FillPageList()
    {
        pages.Add(new StatsPage());
        pages.Add(new SkillsAndAbilityScoresPage());
        pages.Add(new FeaturesAndTraitsPage());
        pages.Add(new WeaponsPage());
        pages.Add(new SpellsPage());
        pages.Add(new InventoryPage());
        pages.Add(new ProficienciesPage());
        pages.Add(new StorytellingPage());
        pages.Add(new DeathSavesPage());
    }

    private void FillCharViewStack()
    {
        foreach (var page in pages)
        {
            var imgBtn = new ImageButtonView(page.Title, "dice_red4.png", CreateCommand(page));
            CharViewStack.Add(imgBtn);
        }
    }

    private void AddRouting()
    {
        foreach (var page in pages)
        {
            Routing.RegisterRoute(page.Title, page.GetType());
        }
    }

    private Command CreateCommand(ContentPage page)
    {
        var cmd = new Command(
            execute: async () =>
            {
                await Shell.Current.GoToAsync(page.Title);
            }
        );
        return cmd;
    }
}