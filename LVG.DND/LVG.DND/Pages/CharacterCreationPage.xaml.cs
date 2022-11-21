using LVG.DND.Models;
using LVG.DND.Views.charcreation;

namespace LVG.DND.Pages;

public partial class CharacterCreationPage : ContentPage
{
	Character character = new Character();
	public CharacterCreationPage()
	{
		InitializeComponent();
        creationStack.Add(new RaceSelector(new ViewModel.RaceSelectorViewModel(character)));

    }
}