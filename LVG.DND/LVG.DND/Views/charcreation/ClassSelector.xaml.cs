using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Views.charcreation;

public partial class ClassSelector : ContentView
{
    ClassSelectorViewModel _vm = new ClassSelectorViewModel();
    public ClassSelector(ClassSelectorViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }
    private void ClassCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _vm.Character.Class = e.CurrentSelection.FirstOrDefault() as CharClass;
    }
}