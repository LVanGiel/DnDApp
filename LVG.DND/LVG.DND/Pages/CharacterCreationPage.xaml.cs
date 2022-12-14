using LVG.DND.Models;
using LVG.DND.Views.charcreation;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages;

public partial class CharacterCreationPage : ContentPage
{
	Character character = new Character();
    private int step;
	public CharacterCreationPage()
	{
		InitializeComponent();
        creationStack.Add(new RaceSelector(new RaceSelectorViewModel(character)));
        step = 0;
    }
    private void CharCreateNextBtn_Clicked(object sender, EventArgs e)
    {
        creationStack.Children.RemoveAt(0);
        NextStep();
    }
    private void NextStep()
    {
        switch (step)
        {
            case 0:
                creationStack.Add(new ClassSelector(new ClassSelectorViewModel(character)));
                step++;
                break;
            case 1:
                creationStack.Add(new BackgroundSelector(new BackgroundSelectorViewModel(character)));
                step++;
                break;
            case 2:
                creationStack.Add(new AbilityScoreCreator(new AbilityScoresViewModel(character)));
                step++;
                break;
            default:
                break;
        }
    }
}