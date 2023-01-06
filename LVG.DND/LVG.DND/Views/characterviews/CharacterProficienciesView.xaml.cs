using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterProficienciesView : ContentView
{
    CharacterProficienciesViewModel _vm;
    Streaming _stream = new Streaming();
    public CharacterProficienciesView(CharacterProficienciesViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
	}
    private void ReloadBindings()
    {
        armorList.ItemsSource = null;
        weaponsList.ItemsSource = null;
        itemsList.ItemsSource = null;
        languagesList.ItemsSource = null;

        armorList.ItemsSource = _vm.Character.ArmorProficiencies;
        weaponsList.ItemsSource = _vm.Character.WeaponProficiencies;
        itemsList.ItemsSource = _vm.Character.ItemProficiencies;
        languagesList.ItemsSource = _vm.Character.LanguageProficiencies;
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var popup = new ProficiencyEditPopup();
        List<string> popupResult = await(this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup) as List<string>;

        if (popupResult == null || popupResult[0] == "" || popupResult[1] == "") { return; }

        if (popupResult[0] == popup.typeList[0])
        {
            if (_vm.Character.WeaponProficiencies == null) { _vm.Character.WeaponProficiencies = new List<string>(); }
            _vm.Character.WeaponProficiencies.Add(popupResult[1]);
        }
        else if (popupResult[0] == popup.typeList[1])
        {
            if (_vm.Character.ArmorProficiencies == null) { _vm.Character.ArmorProficiencies = new List<string>(); }
            _vm.Character.ArmorProficiencies.Add(popupResult[1]);
        }
        else if (popupResult[0] == popup.typeList[2])
        {
            if (_vm.Character.ItemProficiencies == null) { _vm.Character.ItemProficiencies = new List<string>(); }
            _vm.Character.ItemProficiencies.Add(popupResult[1]);
        }
        else
        {
            if (_vm.Character.LanguageProficiencies == null) { _vm.Character.LanguageProficiencies = new List<string>(); }
            _vm.Character.LanguageProficiencies.Add(popupResult[1]);
        }
        await _stream.SaveCharacter(_vm.Character);
        ReloadBindings();
    }

    private async void RemoveButton_Clicked(object sender, EventArgs e)
    {
        var neighbour = ((sender as Button).Parent as Grid).Children[0] as Entry;
        if (_vm.Character.ArmorProficiencies.FirstOrDefault(x=>x==neighbour.Text) != null)
        {
            _vm.Character.ArmorProficiencies.Remove(neighbour.Text);
        }else if(_vm.Character.WeaponProficiencies.FirstOrDefault(x => x == neighbour.Text) != null)
        {
            _vm.Character.WeaponProficiencies.Remove(neighbour.Text);
        }
        else if (_vm.Character.ItemProficiencies.FirstOrDefault(x => x == neighbour.Text) != null)
        {
            _vm.Character.ItemProficiencies.Remove(neighbour.Text);
        }else
        {
            _vm.Character.LanguageProficiencies.Remove(neighbour.Text);
        }
        await _stream.SaveCharacter(_vm.Character);
        ReloadBindings();

    }
}