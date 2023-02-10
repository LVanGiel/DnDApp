using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;

namespace LVG.DND.Pages.character;

public partial class CharacterSpellsPage : ContentPage
{
    BaseCharacterViewModel _vm;
    Streaming _stream = new Streaming();

    List<Spell> spells1 = new List<Spell>();
    List<Spell> spells2 = new List<Spell>();
    List<Spell> spells3 = new List<Spell>();
    List<Spell> spells4 = new List<Spell>();
    List<Spell> spells5 = new List<Spell>();
    List<Spell> spells6 = new List<Spell>();
    List<Spell> spells7 = new List<Spell>();
    List<Spell> spells8 = new List<Spell>();
    List<Spell> spells9 = new List<Spell>();
    public CharacterSpellsPage(BaseCharacterViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
        ReloadBindings();
        AddSpellSlots();
        HideUnneededStacks();
    }
    private bool CheckSpellsSize(List<Spell> spells)
    {
        if (spells.Count == 0)
        {
            return false;
        }
        return true;
    }
    private void HideUnneededStacks()
    {
        CantripsList.IsVisible = CheckSpellsSize(_vm.Character.Cantrips);
        stacklevel1.IsVisible = CheckSpellsSize(spells1);
        stacklevel2.IsVisible = CheckSpellsSize(spells2);
        stacklevel3.IsVisible = CheckSpellsSize(spells3);
        stacklevel4.IsVisible = CheckSpellsSize(spells4);
        stacklevel5.IsVisible = CheckSpellsSize(spells5);
        stacklevel6.IsVisible = CheckSpellsSize(spells6);
        stacklevel7.IsVisible = CheckSpellsSize(spells7);
        stacklevel8.IsVisible = CheckSpellsSize(spells8);
        stacklevel9.IsVisible = CheckSpellsSize(spells9);
    }
    private double CheckSpellSlots(int maxSlots, int slots) 
    {
        if (maxSlots > 0)
        {
            double result = (double)slots / (double)maxSlots;
            return result;
        }
        return 0;
    }
    private void AddSpellSlots()
    {
        SpellSlotsStack1.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel1Max, _vm.Character.SpellSlotsLevel1);
        SpellSlotsStack2.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel2Max, _vm.Character.SpellSlotsLevel2);
        SpellSlotsStack3.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel3Max, _vm.Character.SpellSlotsLevel3);
        SpellSlotsStack4.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel4Max, _vm.Character.SpellSlotsLevel4);
        SpellSlotsStack5.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel5Max, _vm.Character.SpellSlotsLevel5);
        SpellSlotsStack6.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel6Max, _vm.Character.SpellSlotsLevel6);
        SpellSlotsStack7.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel7Max, _vm.Character.SpellSlotsLevel7);
        SpellSlotsStack8.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel8Max, _vm.Character.SpellSlotsLevel8);
        SpellSlotsStack9.Progress = CheckSpellSlots(_vm.Character.SpellSlotsLevel9Max, _vm.Character.SpellSlotsLevel9);
    }
    private void FillSpellsLists()
    {
        spells1.Clear();
        spells2.Clear();
        spells3.Clear();
        spells4.Clear();
        spells5.Clear();
        spells6.Clear();
        spells7.Clear();
        spells8.Clear();
        spells9.Clear();

        foreach (Spell spell in _vm.Character.Spells)
        {
            switch (spell.SpellLevel)
            {
                case 1:
                    spells1.Add(spell);
                    break;
                case 2:
                    spells2.Add(spell);
                    break;
                case 3:
                    spells3.Add(spell);
                    break;
                case 4:
                    spells4.Add(spell);
                    break;
                case 5:
                    spells5.Add(spell);
                    break;
                case 6:
                    spells6.Add(spell);
                    break;
                case 7:
                    spells7.Add(spell);
                    break;
                case 8:
                    spells8.Add(spell);
                    break;
                case 9:
                    spells9.Add(spell);
                    break;
                default:
                    break;
            }
        }
    }

    private void ReloadBindings()
    {
        FillSpellsLists();
        CantripsList.ItemsSource = null;
        SpellsList1.ItemsSource = null;
        SpellsList2.ItemsSource = null;
        SpellsList3.ItemsSource = null;
        SpellsList4.ItemsSource = null;
        SpellsList5.ItemsSource = null;
        SpellsList6.ItemsSource = null;
        SpellsList7.ItemsSource = null;
        SpellsList8.ItemsSource = null;
        SpellsList9.ItemsSource = null;

        CantripsList.ItemsSource = _vm.Character.Cantrips;
        SpellsList1.ItemsSource = spells1;
        SpellsList2.ItemsSource = spells2;
        SpellsList3.ItemsSource = spells3;
        SpellsList4.ItemsSource = spells4;
        SpellsList5.ItemsSource = spells5;
        SpellsList6.ItemsSource = spells6;
        SpellsList7.ItemsSource = spells7;
        SpellsList8.ItemsSource = spells8;
        SpellsList9.ItemsSource = spells9;
    }
    private async void AddSpellButton_Clicked(object sender, EventArgs e)
    {
        var popup = new SpellEditPopup(new SpellPopupViewModel());
        var popupResult = (await (this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup)) as Spell;

        if (popupResult == null) { return; }

        if (popupResult.SpellLevel == 0)
        {
            _vm.Character.Cantrips.Add(popupResult);
        }
        else
        {
            _vm.Character.Spells.Add(popupResult);
        }
        ReloadBindings();
        await _vm.Character.SaveCharacter(_vm.Character);
        HideUnneededStacks();
    }

    private async void UseSpellSlot_Clicked(object sender, EventArgs e)
    {
        var neighbour = ((sender as Button).Parent.Parent as VerticalStackLayout).Children[0] as Label;
        switch (neighbour.Text)
        {
            case "Level 1":
                _vm.Character.SpellSlotsLevel1--;
                    break;
            case "Level 2":
                _vm.Character.SpellSlotsLevel2--;
                break;
            case "Level 3":
                _vm.Character.SpellSlotsLevel3--;
                break;
            case "Level 4":
                _vm.Character.SpellSlotsLevel4--;
                break;
            case "Level 5":
                _vm.Character.SpellSlotsLevel5--;
                break;
            case "Level 6":
                _vm.Character.SpellSlotsLevel6--;
                break;
            case "Level 7":
                _vm.Character.SpellSlotsLevel7--;
                break;
            case "Level 8":
                _vm.Character.SpellSlotsLevel8--;
                break;
            case "Level 9":
                _vm.Character.SpellSlotsLevel9--;
                break;
            default:
                break;
        }
        AddSpellSlots();

        await _vm.Character.SaveCharacter(_vm.Character);
    }

    private async void UnuseSpellSlot_Clicked(object sender, EventArgs e)
    {
        var neighbour = ((sender as Button).Parent.Parent as VerticalStackLayout).Children[0] as Label;
        switch (neighbour.Text)
        {
            case "Level 1":
                _vm.Character.SpellSlotsLevel1 += (_vm.Character.SpellSlotsLevel1 < _vm.Character.SpellSlotsLevel1Max)?1:0;
                break;
            case "Level 2":
                _vm.Character.SpellSlotsLevel2 += (_vm.Character.SpellSlotsLevel2 < _vm.Character.SpellSlotsLevel2Max) ? 1 : 0; ;
                break;
            case "Level 3":
                _vm.Character.SpellSlotsLevel3 += (_vm.Character.SpellSlotsLevel3 < _vm.Character.SpellSlotsLevel3Max) ? 1 : 0; ;
                break;
            case "Level 4":
                _vm.Character.SpellSlotsLevel4 += (_vm.Character.SpellSlotsLevel4 < _vm.Character.SpellSlotsLevel4Max) ? 1 : 0; ;
                break;
            case "Level 5":
                _vm.Character.SpellSlotsLevel5 += (_vm.Character.SpellSlotsLevel5 < _vm.Character.SpellSlotsLevel5Max) ? 1 : 0; ;
                break;
            case "Level 6":
                _vm.Character.SpellSlotsLevel6 += (_vm.Character.SpellSlotsLevel6 < _vm.Character.SpellSlotsLevel6Max) ? 1 : 0; ;
                break;
            case "Level 7":
                _vm.Character.SpellSlotsLevel7 += (_vm.Character.SpellSlotsLevel7 < _vm.Character.SpellSlotsLevel7Max) ? 1 : 0; ;
                break;
            case "Level 8":
                _vm.Character.SpellSlotsLevel8 += (_vm.Character.SpellSlotsLevel8 < _vm.Character.SpellSlotsLevel8Max) ? 1 : 0; ;
                break;
            case "Level 9":
                _vm.Character.SpellSlotsLevel9 += (_vm.Character.SpellSlotsLevel9 < _vm.Character.SpellSlotsLevel9Max) ? 1 : 0; ;
                break;
            default:
                break;
        }
        AddSpellSlots();
        await _vm.Character.SaveCharacter(_vm.Character);
    }

    private async void AddSpellSlotButton_Clicked(object sender, EventArgs e)
    {
        var popup = new AddSpellSlotPopup(_vm.Character.SpellSlotsLevel1Max,
                                          _vm.Character.SpellSlotsLevel2Max,
                                          _vm.Character.SpellSlotsLevel3Max,
                                          _vm.Character.SpellSlotsLevel4Max,
                                          _vm.Character.SpellSlotsLevel5Max,
                                          _vm.Character.SpellSlotsLevel6Max,
                                          _vm.Character.SpellSlotsLevel7Max,
                                          _vm.Character.SpellSlotsLevel8Max,
                                          _vm.Character.SpellSlotsLevel9Max);
        var popupResult = (await(this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup)) as List<int>;

        if (popupResult == null) { return; }

        _vm.Character.SpellSlotsLevel1Max = popupResult[0];
        _vm.Character.SpellSlotsLevel2Max = popupResult[1];
        _vm.Character.SpellSlotsLevel3Max = popupResult[2];
        _vm.Character.SpellSlotsLevel4Max = popupResult[3];
        _vm.Character.SpellSlotsLevel5Max = popupResult[4];
        _vm.Character.SpellSlotsLevel6Max = popupResult[5];
        _vm.Character.SpellSlotsLevel7Max = popupResult[6];
        _vm.Character.SpellSlotsLevel8Max = popupResult[7];
        _vm.Character.SpellSlotsLevel9Max = popupResult[8];

        _vm.Character.SpellSlotsLevel1 = popupResult[0];
        _vm.Character.SpellSlotsLevel2 = popupResult[1];
        _vm.Character.SpellSlotsLevel3 = popupResult[2];
        _vm.Character.SpellSlotsLevel4 = popupResult[3];
        _vm.Character.SpellSlotsLevel5 = popupResult[4];
        _vm.Character.SpellSlotsLevel6 = popupResult[5];
        _vm.Character.SpellSlotsLevel7 = popupResult[6];
        _vm.Character.SpellSlotsLevel8 = popupResult[7];
        _vm.Character.SpellSlotsLevel9 = popupResult[8];

        ReloadBindings();
        await _vm.Character.SaveCharacter(_vm.Character);
        HideUnneededStacks();
        AddSpellSlots();
    }

    private async void DeleteSpell_Clicked(object sender, EventArgs e)
    {
        var senderParent = (sender as Button).Parent as Grid;
        var neighbour = senderParent.Children[0] as VerticalStackLayout;
        var nameLabel = neighbour.Children[0] as Label;
        int level = int.Parse((neighbour.Children[1] as Label).Text);
        if (level == 0)
        {
            _vm.Character.Cantrips.Remove(_vm.Character.Cantrips.First(x=>x.Name == nameLabel.Text));
        }
        else
        {
            _vm.Character.Spells.Remove(_vm.Character.Spells.First(x => x.Name == nameLabel.Text));
        }
        ReloadBindings();
        await _vm.Character.SaveCharacter(_vm.Character);
        HideUnneededStacks();
    }
    private async void EditSpellClass_Clicked(object sender, EventArgs e)
    {
        txtSpellClass.IsEnabled = !txtSpellClass.IsEnabled;
        txtSpellAbility.IsEnabled = !txtSpellAbility.IsEnabled;
        txtSpellSaveDC.IsEnabled = !txtSpellSaveDC.IsEnabled;
        txtSpellAttackBonus.IsEnabled = !txtSpellAttackBonus.IsEnabled;
        if ((sender as Button).Text == "Edit")
        {
            (sender as Button).Text = "Save";
        }
        else
        {
            (sender as Button).Text = "Edit";
            await _vm.Character.SaveCharacter(_vm.Character);
        }

        
    }
}