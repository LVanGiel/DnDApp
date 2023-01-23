using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages.charcreation;

public partial class BackgroundSelector : ContentPage
{
    BackgroundSelectorViewModel _vm = new BackgroundSelectorViewModel();
    public BackgroundSelector(BackgroundSelectorViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
    private void BackgroundCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _vm.Character.Background = e.CurrentSelection.FirstOrDefault() as Background;
    }
}