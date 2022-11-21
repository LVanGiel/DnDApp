using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASManualInput : ContentView
{
    AbilityScoresViewModel _vm = new AbilityScoresViewModel();
    public ASManualInput(AbilityScoresViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
}