using CommunityToolkit.Maui.Views;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;

namespace LVG.DND.Pages.character;

public partial class StartCombat : ContentPage
{
    private BaseCharacterViewModel _vm;
    public StartCombat(BaseCharacterViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
        Init();
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

        AttackBtn.ButtonImageUrl = "attack.png";
        AttackBtn.ButtonClicked += AttackButton_Clicked;

        ItemsBtn.ButtonImageUrl = "items.png";
        ItemsBtn.ButtonClicked += ItemsButton_Clicked;

        SkillsBtn.ButtonImageUrl = "skill.png";
        SkillsBtn.ButtonClicked += SkillButton_Clicked;

        TraitsBtn.ButtonImageUrl = "trait.png";

        SavingBtn.ButtonImageUrl = "dice_red20.png";
    }

    private void SubmitInitiative_Clicked(object sender, EventArgs e)
    {
        ((sender as Button).Parent as VerticalStackLayout).IsVisible = false;
        if (InitativeEntry.Text == "" || InitativeEntry.Text == null)
        {
            InitiativeBtn.ButtonStat = (InitiativeDiceView.dice.Number + _vm.Character.Initiative).ToString();
        }
        else
        {
            if (InitativeEntry.Text == null || InitativeEntry.Text == "")
            {
                return;
            }
            InitiativeBtn.ButtonStat = (int.Parse(InitativeEntry.Text) + _vm.Character.Initiative).ToString();
        }
        BattleStack.IsVisible = true;
    }

    private async void RollChoiceButton_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button).Text == "Roll in app") 
        {
            RollInApp.IsVisible = true;
            await InitiativeDiceView.dice.RollDice(20);
        }
        else
        {
            InputStack.IsVisible = true;
        }
        ((sender as Button).Parent as VerticalStackLayout).IsVisible = false;
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
    private async void ArmorButton_Clicked(object sender, EventArgs e)
    {
        EquipmentPage equipmentPage = new EquipmentPage(_vm);
        await Navigation.PushAsync(equipmentPage);
    }
    private async void AttackButton_Clicked(object sender, EventArgs e)
    {
        AttackPage attackPage = new AttackPage(_vm);
        await Navigation.PushAsync(attackPage);
    }
    private async void SpeedButton_Clicked(object sender, EventArgs e)
    {
        SpeedPopup healthPopup = new SpeedPopup(_vm.Character);
        await this.ShowPopupAsync(healthPopup);
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