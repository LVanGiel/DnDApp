using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;

namespace LVG.DND.Pages.character;

public partial class AttackPage : ContentPage
{
    BaseCharacterViewModel _vm;
    SpellsView spellview;
    public AttackPage(BaseCharacterViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
        AddSpells();

    }
    private void AddSpells()
    {
        if (_vm.Character.Spells.Count > 0 || _vm.Character.Cantrips.Count > 0)
        {
            spellview = new SpellsView(_vm);
            mainStack.Children.Add(spellview);
        }
    }
    private void RefreshBinding()
    {
        WeaponListView.ItemsSource = null;
        WeaponListView.ItemsSource = _vm.Character.Weapons;
    }
    private async void RollDamage()
    {
        Weapon weapon = WeaponListView.SelectedItem as Weapon;
        AttackRollDice.IsVisible = true;
        AttackRollDice.dice.ChangeSize(weapon.DiceSize);

        List<int> damageRolls = new List<int>();

        for (int i = 0; i < weapon.DiceCount; i++)
        {
            await AttackRollDice.dice.RollDice(weapon.DiceSize);
            int result = AttackRollDice.dice.Number;
            damageRolls.Add(result);
            Task.Delay(750).Wait();
        }
        int damageTotal = 0;
        foreach (int damage in damageRolls)
        {
            damageTotal += damage;
        }
        damageTotal += weapon.DamageBonus;
        TotalAttackRollLabel.Text = $"Total damage: {damageTotal}";

        HitOrMissStack.IsVisible = false;
    }

    private void WeaponListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Weapon selectedWeapon = (sender as ListView).SelectedItem as Weapon;
        SelectedWeaponLabel.IsVisible = true;
        SelectedWeaponLabel.Text = selectedWeapon.Name;

        AttackRollStack.IsVisible = true;

    }
    private void SubmitAttackRoll(object sender, EventArgs e)
    {
        if (AttackRollManualEntry.Text == null || AttackRollManualEntry.Text == "")
        {
            return;
        }
        Weapon weapon = WeaponListView.SelectedItem as Weapon;
        TotalAttackRollLabel.Text = $"Dice roll: {AttackRollManualEntry.Text} Total attack points: {int.Parse(AttackRollManualEntry.Text) + weapon.AttackBonus}";

        (sender as Button).IsVisible = false;
        AttackRollManualEntry.IsVisible = false;
    }
    private async void RollInAppAttack(object sender, EventArgs e)
    {
        Weapon weapon = WeaponListView.SelectedItem as Weapon;
        (sender as Button).IsVisible = false;
        ManualAttackRollStack.IsVisible = false;
        WeaponListView.IsVisible = false;

        spellview.IsVisible = false;
        AttackRollDice.IsVisible = true;
        await AttackRollDice.dice.RollDice(20);

        TotalAttackRollLabel.Text = $"Dice roll: {AttackRollDice.dice.Number} Total attack points: {AttackRollDice.dice.Number + weapon.AttackBonus}";

        if (AttackRollDice.dice.Number < 20)
        {
            HitOrMissStack.IsVisible = true;
        }
        AttackRollDice.IsVisible = false;
        if (AttackRollDice.dice.Number >= 20)
        {
            RollDamage();
        }
    }

    private void HitClicked(object sender, EventArgs e)
    {
        RollDamage();
    }
}