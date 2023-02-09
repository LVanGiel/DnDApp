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
        Init();
        BindingContext = _vm;
    }
    private void Init()
    {
        ArmorClassBtn.ButtonStat = _vm.Character.ArmorPoints.ToString();
        ArmorClassBtn.ButtonImageUrl = "shield.png";
        ArmorClassBtn.ButtonClicked += ArmorButton_Clicked;

        SpeedBtn.ButtonStat = _vm.Character.BaseSpeed.ToString();
        SpeedBtn.ButtonImageUrl = "speed.png";
        SpeedBtn.ButtonClicked += SpeedButton_Clicked;

        HealthBtn.ButtonStat = (_vm.Character.CurrentHealth + _vm.Character.TemporaryHealth).ToString();
        HealthBtn.ButtonImageUrl = "health.png";
        HealthBtn.ButtonClicked += HealthButton_Clicked;

        ItemsBtn.ButtonImageUrl = "items.png";
        ItemsBtn.ButtonClicked += ItemsButton_Clicked;

        SkillsBtn.ButtonImageUrl = "skill.png";
        SkillsBtn.ButtonClicked += SkillButton_Clicked;

        CombatBtn.ButtonImageUrl = "attack.png";
        CombatBtn.ButtonClicked += CombatButton_Clicked;

        SpellsBtn.ButtonImageUrl = "spells.png";

        DamageBtn.ButtonImageUrl = "damage.png";
    }
    private async void ArmorButton_Clicked(object sender, EventArgs e)
    {
        EquipmentPage equipmentPage = new EquipmentPage(_vm);
        await Navigation.PushAsync(equipmentPage);
    }
    private async void CombatButton_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(StartCombat), typeof(StartCombat));
        var activeChar = await (new Character()).GetActiveCharacter();
        var vm = new BaseCharacterViewModel(activeChar);
        StartCombat SessionPage = new StartCombat(vm);
        await Navigation.PushAsync(SessionPage);
    }
    private async void SpeedButton_Clicked(object sender, EventArgs e)
    {
        SpeedPopup healthPopup = new SpeedPopup(_vm.Character);
        await this.ShowPopupAsync(healthPopup);
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
    private async void ItemsButton_Clicked(object sender, EventArgs e)
    {
        InventoryPage inventoryPage = new InventoryPage(_vm);
        await Navigation.PushAsync(inventoryPage);
    }
    private async void SkillButton_Clicked(object sender, EventArgs e)
    {
        SkillCheckPage skillPage = new SkillCheckPage(_vm);
        await Navigation.PushAsync(skillPage);
    }
}