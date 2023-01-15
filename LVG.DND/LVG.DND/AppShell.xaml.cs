using LVG.DND.Models;
using LVG.DND.Pages;
using LVG.DND.Pages.character;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;

namespace LVG.DND;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DndDice), typeof(DndDice));
        Routing.RegisterRoute(nameof(CharacterCreationPage), typeof(CharacterCreationPage));
        Routing.RegisterRoute(nameof(CharacterViewMenuPage), typeof(CharacterViewMenuPage));
        Routing.RegisterRoute(nameof(CharacterViewPage), typeof(CharacterViewPage));
        Routing.RegisterRoute(nameof(CharacterCollectionPage), typeof(CharacterCollectionPage));
        Routing.RegisterRoute(nameof(CharacterHome), typeof(CharacterHome));
    }
}
