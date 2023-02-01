using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Pages.character;

public partial class EquipmentPage : ContentPage
{
    BaseCharacterViewModel _vm;
    public EquipmentPage(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
	}
    private void RefreshBinding()
    {
        WeaponListView.ItemsSource = null;
        WeaponListView.ItemsSource = _vm.Character.Weapons;
        ArmorListView.ItemsSource = null;
        ArmorListView.ItemsSource = _vm.Character.Armor;
    }

    private async void SaveCharacter()
    {
        RefreshBinding();
        await _vm.Character.SaveCharacter(_vm.Character);
    }

    private void btnWeaponEdit_Clicked(object sender, EventArgs e)
    {

        string name = ((((sender as Button).Parent as Grid).Children[0] as Grid).Children[0] as Label).Text;
        Weapon deletedWeapon = _vm.Character.Weapons.Find(x => x.Name == name);
        _vm.Character.Weapons.Remove(deletedWeapon);
        SaveCharacter();
        /*(((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible = !(((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible;
        if ((((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible == false)
        {
            (sender as Button).Text = "Edit";
            //SaveCharacter();
        }
        else
        {
            (sender as Button).Text = "Save";
        }*/
    }

    private void btnArmorEdit_Clicked(object sender, EventArgs e)
    {

        string name = ((((sender as Button).Parent as Grid).Children[0] as Grid).Children[0] as Label).Text;
        Armor deletedArmor = _vm.Character.Armor.Find(x => x.Name == name);
        _vm.Character.Armor.Remove(deletedArmor);
        SaveCharacter();
        /*(((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible = !(((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible;
        if ((((sender as Button).Parent as Grid).Children[1] as Grid).IsVisible == false)
        {
            (sender as Button).Text = "Edit";
            //SaveCharacter();
        }
        else
        {
            (sender as Button).Text = "Save";
        }*/
    }

    private void btnWeaponAdd_Clicked(object sender, EventArgs e)
    {
        var weapon = new Weapon()
        {
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
    private void btnArmorAdd_Clicked(object sender, EventArgs e)
    {
        var armor = new Armor()
        {
            Name = txtArmorNameAdd.Text,
            ArmorClass = int.Parse(txtArmorACAdd.Text),
            IsLight = checkLight.IsChecked,
            IsMedium = checkMedium.IsChecked,
            IsHeavy = checkHeavy.IsChecked,
            IsShield = checkShield.IsChecked,
        };
        if (_vm.Character.Armor == null)
        {
            _vm.Character.Armor = new List<Armor>();
        }
        _vm.Character.Armor.Add(armor);
        SaveCharacter();
        txtArmorNameAdd.Text = "";
        txtArmorACAdd.Text = "";
    }
}