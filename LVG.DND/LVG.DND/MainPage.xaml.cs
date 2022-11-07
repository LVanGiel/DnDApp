using CommunityToolkit.Maui.Views;
using LVG.DND.Pages;
using LVG.DND.Views;

namespace LVG.DND;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnRollClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(DndDice));
	}
    private async void OnCharClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DndDice));
    }
}

