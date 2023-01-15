using LVG.DND.Models;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages.charcreation;

public partial class RaceSelector : ContentPage
{
    RaceSelectorViewModel _vm = new RaceSelectorViewModel();
    public RaceSelector()
    {
        RaceSelectorViewModel vm = new RaceSelectorViewModel();
        vm.Character = new Character();
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
    }
    private void SubRaceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        _vm.Character.SubRace = (sender as ListView).SelectedItem as SubRace;
        var grid = (sender as ListView).Parent as VerticalStackLayout;

        string raceName = (grid.Children[0] as Label).Text;
        _vm.Character.Race = _vm.Races.FirstOrDefault(x => x.Name == raceName);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var character = new Dictionary<string, Object> { { "Character", _vm.Character } };
        await Shell.Current.GoToAsync(nameof(ClassSelector), character);
    }
}