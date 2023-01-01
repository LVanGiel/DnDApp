using LVG.DND.Pages;

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
    }
}
