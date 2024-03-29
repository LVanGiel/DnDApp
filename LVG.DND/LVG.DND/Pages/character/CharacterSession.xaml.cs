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
        SpellsBtn.ButtonClicked += SpellsButton_Clicked;

        DamageBtn.ButtonImageUrl = "damage.png";
        DamageBtn.ButtonClicked += DamageButton_Clicked;
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
        _vm.Character.CurrentHealth += strings[0] != "" ? int.Parse(strings[0]) : 0;
        _vm.Character.TemporaryHealth += strings[1] != "" ? int.Parse(strings[1]) : 0;
        _vm.Character.CurrentHealth += (strings[2] != "" && int.Parse(strings[2]) >= 0) 
                                        ? int.Parse(strings[2]) : 0;
        _vm.Character.MaxHealth += strings[2] != "" ? int.Parse(strings[2]) : 0;
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
    private async void SpellsButton_Clicked(object sender, EventArgs e)
    {
        CharacterSpellsPage spellPage = new CharacterSpellsPage(_vm);
        await Navigation.PushAsync(spellPage);
    }
    private async void DamageButton_Clicked(object sender, EventArgs e)
    {
        TakeDamagePopup damagePopup = new TakeDamagePopup(_vm.Character);
        var popupResult = (await this.ShowPopupAsync(damagePopup))as string;
        int result = 0;
        if (popupResult != null)
        {
            result = int.Parse(popupResult);
        }

        if(_vm.Character.TemporaryHealth > 0)
        {
            if (_vm.Character.TemporaryHealth >= result)
            {
                _vm.Character.TemporaryHealth -= result;
            }
            else
            {
                result -= _vm.Character.TemporaryHealth;
                _vm.Character.TemporaryHealth = 0;
            }
        }
        _vm.Character.CurrentHealth -= result;

        await _vm.Character.SaveCharacter(_vm.Character);
        HealthBtn.ButtonStat = (_vm.Character.CurrentHealth + _vm.Character.TemporaryHealth).ToString();
    }
}