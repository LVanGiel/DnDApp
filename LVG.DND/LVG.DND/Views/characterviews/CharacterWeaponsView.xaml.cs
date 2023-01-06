using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterWeaponsView : ContentView
{
    BaseCharacterViewModel _vm;
    Streaming _stream = new Streaming();
    public CharacterWeaponsView(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
	}

    private void RefreshBinding()
    {
        WeaponListView.ItemsSource = null;
        WeaponListView.ItemsSource = _vm.Character.Weapons;
    }

    private async void SaveCharacter()
    {
        RefreshBinding();
        await _stream.SaveCharacter(_vm.Character);
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {

        (((sender as Button).Parent as Grid).Children[0] as Grid).IsVisible = !(((sender as Button).Parent as Grid).Children[0] as Grid).IsVisible;
        (((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible = !(((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible;
        if ((((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible == false)
        {
            (sender as Button).Text = "Edit";
            SaveCharacter();
        }
        else
        {
            (sender as Button).Text = "Save";
        }
    }

    private void btnWeaponAdd_Clicked(object sender, EventArgs e)
    {
        var weapon = new Weapon() {
            Name = txtWeaponNameAdd.Text,
            AttackBonus = int.Parse(txtWeaponBonusAttackAdd.Text),
            DamageType = txtWeaponDamageTypeAdd.Text,
            DiceWithBonus = txtDiceWithBonusAdd.Text
        };
        _vm.Character.Weapons.Add(weapon);
        SaveCharacter();
        txtWeaponNameAdd.Text = "";
        txtWeaponBonusAttackAdd.Text = "";
        txtWeaponDamageTypeAdd.Text = "";
        txtDiceWithBonusAdd.Text = "";
    }
}