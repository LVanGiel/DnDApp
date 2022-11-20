using LVG.DND.ViewModel;

namespace LVG.DND.Views.charcreation;

public partial class RaceSelector : ContentView
{
    public RaceSelector(RaceSelectorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{

	}
}