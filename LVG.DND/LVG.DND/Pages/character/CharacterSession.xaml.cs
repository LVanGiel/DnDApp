using LVG.DND.ViewModel.characterViewModels;

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
    }
}