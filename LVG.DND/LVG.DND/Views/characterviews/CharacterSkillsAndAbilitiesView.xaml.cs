using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterSkillsAndAbilitiesView : ContentView
{
    CharacterSkillsAndAbilityscoresViewModel _vm;
    Streaming stream = new Streaming();

    public CharacterSkillsAndAbilitiesView(CharacterSkillsAndAbilityscoresViewModel vm)
	{
        _vm = vm;
        BindingContext= _vm;
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        ASListView.ItemsSource = null;
        ASListView.ItemsSource = _vm.Character.AbilityScores;
        await stream.SaveCharacter(_vm.Character);
    }
}