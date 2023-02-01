using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Pages.character;

public partial class AttackPage : ContentPage
{
    BaseCharacterViewModel _vm;
    public AttackPage(BaseCharacterViewModel vm)
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
        await _vm.Character.SaveCharacter(_vm.Character);
    }
    private void btnWeaponDelete_Clicked(object sender, EventArgs e)
    {

        string name = ((((sender as Button).Parent as Grid).Children[0] as Grid).Children[0] as Label).Text;
        Weapon deletedWeapon = _vm.Character.Weapons.Find(x => x.Name == name);
        _vm.Character.Weapons.Remove(deletedWeapon);
        SaveCharacter();
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
}