using LVG.DND.Models;
using LVG.DND.ViewModel;
using Newtonsoft.Json;

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
        this.Loaded += new EventHandler(This_Loaded);
    }

    private void FillRaceNames()
    {
        List<string> raceNames = new List<string>();
        raceNames.Clear();
        foreach (Race race in _vm.Races)
        {
            raceNames.Add(race.Name);
        }
        RacePicker.ItemsSource = raceNames;
        RacePicker.ItemsSource = RacePicker.GetItemsAsArray();
        RacePicker.SelectedIndex = 0;
    }

    private void FillSubRaceNames(Race activeRace)
    {
        List<string> raceNames = new List<string>();
        raceNames.Clear();
        foreach (SubRace race in activeRace.SubRaces)
        {
            raceNames.Add(race.Name);
        }
        SubRacePicker.ItemsSource = raceNames;
        SubRacePicker.ItemsSource = SubRacePicker.GetItemsAsArray();
        SubRacePicker.SelectedIndex = 0;
    }

    private void This_Loaded(object sender, EventArgs e)
    {
        FillRaceNames();
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
        var basepath = FileSystem.Current.CacheDirectory;
        var pathString = Path.Combine(basepath, "temporaryCharacter.txt");
        await File.WriteAllTextAsync(pathString, JsonConvert.SerializeObject(_vm.Character));
        await Shell.Current.GoToAsync($"{nameof(ClassSelector)}");
    }

    private void RacePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string raceName = (sender as Picker).SelectedItem as string;
        Race activeRace = _vm.Races.FirstOrDefault(x => x.Name == raceName);
        _vm.Character.Race = activeRace;

        RaceNameLabel.Text = activeRace.Name;
        RaceBackstoryEditor.Text = activeRace.Backstory;
        RaceTraitsList.ItemsSource = activeRace.Traits;
        RaceAbilityScoreList.ItemsSource = activeRace.ASBonus;
        RaceWeaponProficienciesList.ItemsSource = activeRace.WeaponProficiencies;
        RaceItemProficienciesList.ItemsSource = activeRace.ItemProficiencies;
        RaceWalkingSpeedLabel.Text = activeRace.BaseWalkingSpeed.ToString();
        RaceFlyingSpeedLabel.Text = activeRace.BaseFlyingSpeed.ToString();
        FillSubRaceNames(activeRace);
    }

    private void SubRacePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string raceName = RacePicker.SelectedItem as string;
        Race activeRace = _vm.Races.FirstOrDefault(x => x.Name == raceName);

        string subRaceName = (sender as Picker).SelectedItem as string;
        SubRace activeSubRace = activeRace.SubRaces.FirstOrDefault(x => x.Name == subRaceName);

        _vm.Character.SubRace = activeSubRace;

        if (activeSubRace == null)
        {
            return;
        }

        SubRaceNameLabel.Text = activeSubRace.Name;
        SubRaceBackstoryEditor.Text = activeSubRace.Backstory;
        SubRaceTraitsList.ItemsSource = activeSubRace.Traits;
        SubRaceAbilityScoreList.ItemsSource = activeSubRace.AbilityScoreBonus;
        SubRaceWeaponProficienciesList.ItemsSource = activeSubRace.WeaponProficiencies;
        SubRaceSpellsList.ItemsSource = activeSubRace.SpellsAndCantrips;
        SubRaceWalkingSpeedLabel.Text = activeSubRace.BaseWalkingSpeed.ToString();
    }
}