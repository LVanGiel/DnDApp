using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Views.charcreation.AbilityScores;

public partial class ASManualInput : ContentView
{
    CharCreateViewModel _vm = new CharCreateViewModel();
    public ASManualInput(CharCreateViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
}