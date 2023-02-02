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
}