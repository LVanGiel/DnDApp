using LVG.DND.Views.charcreation;

namespace LVG.DND.Pages;

public partial class CharacterCreationPage : ContentPage
{
	public CharacterCreationPage()
	{
		InitializeComponent();
        creationStack.Add(new RaceSelector(new ViewModel.RaceSelectorViewModel()));

    }
}