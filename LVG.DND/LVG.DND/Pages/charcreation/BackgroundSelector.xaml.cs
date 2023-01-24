using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages.charcreation;

public partial class BackgroundSelector : ContentPage
{
    CharCreateViewModel _vm = new CharCreateViewModel();
    public BackgroundSelector(CharCreateViewModel vm)
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