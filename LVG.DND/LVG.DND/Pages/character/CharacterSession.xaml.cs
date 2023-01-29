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

        HealthBtn.ButtonStat = _vm.Character.CurrentHealth.ToString();
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
        EditHealthPopup healthPopup  = new EditHealthPopup();
        await this.ShowPopupAsync(healthPopup);
    }
}