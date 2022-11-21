using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Views.charcreation;

public partial class RaceSelector : ContentView
{
    RaceSelectorViewModel _vm = new RaceSelectorViewModel();
    public RaceSelector(RaceSelectorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        _vm.Character.Race = e.CurrentSelection.FirstOrDefault() as Race;
	}
}