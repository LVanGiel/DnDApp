using LVG.DND.Models;
using LVG.DND.Models.basemodel;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using Newtonsoft.Json;
using System.Linq;

namespace LVG.DND.Pages.charcreation;

public partial class RaceSelector : ContentPage
{
    CharCreateViewModel _vm = new CharCreateViewModel();
    List<Item> unSelectedItems = new List<Item>();
    List<Item> selectedItems = new List<Item>();


    List<Item> itemChoices = new List<Item>
        {
            new Item{Name = "Smith's tools", Description = "Smith's tools allow you to work metal, beating it to alter its shape, repair damage, or work raw ingots into useful items. Components: Smith's tools include hammers, tongs, charcoal, rags, and a whetstone. Arcana and History: Your expertise lends you additional insight when examining metal objects, such as weapons. Investigation: You can spot clues and make deductions that others might overlook when an investigation involves armor, weapons, or other metalwork. Repair: With access to your tools and an open flame hot enough to make metal pliable, you can restore 10 hit points to a damaged metal object for each hour of work."},
            new Item{Name = "Brewer's supplies", Description = "Brewing is the art of producing beer. Not only does beer serve as an alcoholic beverage, but the process of brewing purifies water. Crafting beer takes weeks of fermentation, but only a few hours of work. Components: Brewer's supplies include a large glass jug, a quantity of hops, a siphon, and several feet of tubing. History: Proficiency with brewer's supplies gives you additional insight on Intelligence (History) checks concerning events that involve alcohol as a significant element. Medicine: This tool proficiency grants additional insight when you treat anyone suffering from alcohol poisoning or when you can use alcohol to dull pain. Persuasion: A stiff drink can help soften the hardest heart. Your proficiency with brewer's supplies can help you ply someone with drink, giving them just enough alcohol to mellow their mood. Potable Water: Your knowledge of brewing enables you to purify water that would otherwise be undrinkable. As part of a long rest, you can purify up to 6 gallons of water, or 1 gallon as part of a short rest."},
            new Item{Name = "Mason's tools", Description = "Mason's tools allow you to craft stone structures, including walls and buildings crafted from brick. Components: Mason's tools consist of a trowel, a hammer, a chisel, brushes, and a square. History: Your expertise aids you in identifying a stone building's date of construction and purpose, along with insight into who might have built it. Investigation: You gain additional insight when inspecting areas within stone structures. Perception: You can spot irregularities in stone walls or floors, making it easier to find trap doors and secret passages. Demolition: Your knowledge of masonry allows you to spot weak points in brick walls. You deal double damage to such structures with your weapon attacks."}
        };
    public RaceSelector()
    {
        CharCreateViewModel vm = new CharCreateViewModel();
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
    private async void This_Loaded(object sender, EventArgs e)
    {
        var raceStream = new StreamRaces();
        _vm.Races = await raceStream.GetAllRaces();
        var classStream = new StreamClasses();
        _vm.Classes = await classStream.GetAllClasses();
        var backgroundStream = new StreamBackgrounds();
        _vm.Backgrounds = await backgroundStream.GetAllBackgrounds();
        FillRaceNames();
    }
    private void SubRaceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        _vm.Character.SubRace = ((sender as ListView).SelectedItem as SubRace).Name;
        var grid = (sender as ListView).Parent as VerticalStackLayout;

        string raceName = (grid.Children[0] as Label).Text;
        _vm.Character.Race = _vm.Races.FirstOrDefault(x => x.Name == raceName).Name;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        foreach (Item item in selectedItems)
        {
            _vm.Character.ItemProficiencies.Add(item.Name);
        }
        ClassSelector classPage = new ClassSelector(_vm);
        await Navigation.PushAsync(classPage);
    }

    private void RacePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string raceName = (sender as Picker).SelectedItem as string;
        Race activeRace = _vm.Races.FirstOrDefault(x => x.Name == raceName);
        _vm.Character.Race = activeRace;

        int choiceCount = 0;
        if (_vm.Character.Race != null 
            && _vm.Character.Race != "" 
            && activeRace.ItemProficiencies != null)
        {
            foreach (string item in activeRace.ItemProficiencies)
            {
                if (item == "Choice")
                {
                    choiceCount++;
                }
            }
        }

        if (choiceCount > 0)
        {
            choiceCount++;
            RaceItemStack.IsVisible = true;
            RaceItemsList.ItemsSource = itemChoices;
            unSelectedItems = itemChoices;
        }
        else
        {
            RaceItemStack.IsVisible = false;
        }

        RaceBackstoryEditor.Text = activeRace.Backstory;
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
    }

    private void RaceItemsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(_vm.Character.ItemProficiencies == null)
        {
            _vm.Character.ItemProficiencies = new List<string>();
        }
        if (selectedItems.Count > 0)
        {
            unSelectedItems.Add(selectedItems[0]);
            selectedItems = new List<Item>();
        }
        selectedItems.Add((sender as ListView).SelectedItem as Item);
        unSelectedItems.Remove((sender as ListView).SelectedItem as Item);

        RaceItemsList.ItemsSource = null;
        RaceSelectedItemsList.ItemsSource = null;

        RaceItemsList.ItemsSource = unSelectedItems;
        RaceSelectedItemsList.ItemsSource = selectedItems;
    }
}