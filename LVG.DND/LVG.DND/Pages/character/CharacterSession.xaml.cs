using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;

namespace LVG.DND.Pages.character;

public partial class CharacterSession : ContentPage
{
    private BaseCharacterViewModel _vm;
    public CharacterSession(BaseCharacterViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
		ArmorClassBtn.ButtonStat = _vm.Character.ArmorPoints.ToString();
		ArmorClassBtn.ButtonImageUrl = "shield.png";

        SpeedBtn.ButtonStat = _vm.Character.BaseSpeed.ToString();
        SpeedBtn.ButtonImageUrl = "speed.png";

        HealthBtn.ButtonStat = (_vm.Character.CurrentHealth + _vm.Character.TemporaryHealth).ToString();
        HealthBtn.ButtonImageUrl = "health.png";
        HealthBtn.ButtonClicked += HealthButton_Clicked;
    }

    private async void CombatButton_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(StartCombat), typeof(StartCombat));
        var activeChar = await (new Character()).GetActiveCharacter();
        var vm = new BaseCharacterViewModel(activeChar);
        StartCombat SessionPage = new StartCombat(vm);
        await Navigation.PushAsync(SessionPage);
    }
    private async void HealthButton_Clicked(object sender, EventArgs e)
    {
        EditHealthPopup healthPopup = new EditHealthPopup(_vm.Character);
        List<string> strings = (await this.ShowPopupAsync(healthPopup)) as List<string>;
        _vm.Character.CurrentHealth = int.Parse(strings[0]);
        _vm.Character.TemporaryHealth = int.Parse(strings[1]);
        await _vm.Character.SaveCharacter(_vm.Character);
        HealthBtn.ButtonStat = (_vm.Character.CurrentHealth + _vm.Character.TemporaryHealth).ToString();
    }
}