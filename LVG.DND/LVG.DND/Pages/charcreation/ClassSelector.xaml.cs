using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages.charcreation;
public partial class ClassSelector : ContentPage
{
    public ClassSelectorViewModel _vm;
    public ClassSelector(ClassSelectorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    private void ClassCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _vm.Character.Class = e.CurrentSelection.FirstOrDefault() as CharClass;
    }
}