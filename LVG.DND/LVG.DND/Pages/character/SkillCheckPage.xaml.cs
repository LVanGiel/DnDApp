using CommunityToolkit.Maui.Views;
using LVG.DND.ViewModel.characterViewModels;
using LVG.DND.Views;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace LVG.DND.Pages.character;

public partial class SkillCheckPage : ContentPage
{
	BaseCharacterViewModel _vm;

    public SkillCheckPage(BaseCharacterViewModel vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
		Init();
	}
	private void Init()
	{
		StrengthBtn.ButtonStat = _vm.Character.StrengthSave.BonusText;
        AthleticsBtn.ButtonStat = _vm.Character.Athletics.BonusText;

        DexterityBtn.ButtonStat = _vm.Character.DexteritySave.BonusText;
        AcrobaticsBtn.ButtonStat = _vm.Character.Acrobatics.BonusText;
        SleightOfHandBtn.ButtonStat = _vm.Character.SleightOfHand.BonusText;
        StealthBtn.ButtonStat = _vm.Character.Stealth.BonusText;

        ConstitutionBtn.ButtonStat = _vm.Character.ConstitutionSave.BonusText;

        IntelligenceBtn.ButtonStat = _vm.Character.IntelligenceSave.BonusText;
        ArcanaBtn.ButtonStat = _vm.Character.Arcana.BonusText;
        HistoryBtn.ButtonStat = _vm.Character.History.BonusText;
        InvestigationBtn.ButtonStat = _vm.Character.Investigation.BonusText;
        NatureBtn.ButtonStat = _vm.Character.Nature.BonusText;
        ReligionBtn.ButtonStat = _vm.Character.Religion.BonusText;

        WisdomBtn.ButtonStat = _vm.Character.WisdomSave.BonusText;
        AnimalHandlingBtn.ButtonStat = _vm.Character.AnimalHandling.BonusText;
        InsightBtn.ButtonStat = _vm.Character.Insight.BonusText;
        MedicineBtn.ButtonStat = _vm.Character.Medicine.BonusText;
        PerceptionBtn.ButtonStat = _vm.Character.Perception.BonusText;
        SurvivalBtn.ButtonStat = _vm.Character.Survival.BonusText;

        CharismaBtn.ButtonStat = _vm.Character.CharismaSave.BonusText;
        DeceptionBtn.ButtonStat = _vm.Character.Deception.BonusText;
        IntimidationBtn.ButtonStat = _vm.Character.Intimidation.BonusText;
        PerformanceBtn.ButtonStat = _vm.Character.Performance.BonusText;
        PersuasionBtn.ButtonStat = _vm.Character.Persuasion.BonusText;

        strengthStack.IsVisible = true;
        dexStack.IsVisible = false;
        constStack.IsVisible = false;
        intelStack.IsVisible = false;
        wisStack.IsVisible = false;
        charStack.IsVisible = false;

        foreach (var buttonChild in strengthStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
        foreach (var buttonChild in dexStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
        foreach (var buttonChild in constStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
        foreach (var buttonChild in intelStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
        foreach (var buttonChild in wisStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
        foreach (var buttonChild in charStack.Children)
        {
            var button = buttonChild as StatButton;
            button.ButtonClicked += Button_Clicked;
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = (sender as Button);
        var parent = button.Parent as Grid;
        string name = (parent.Children[2] as Label).Text;

        List<int> size = new List<int>();
        size.Add(20);
        var dicePopup = new DicePopup(size, true);
        dicePopup.CanBeDismissedByTappingOutsideOfPopup = false;

        List<int> results = await this.ShowPopupAsync(dicePopup) as List<int>;
        int result = results[0];

        int total = AddToSkill(name, result);
        resultStack.IsVisible = true;
        buttonStack.IsVisible = false;

        resultLabel.Text = total.ToString();
    }
    private int AddToSkill(string name, int value)
    {
        int total = 0;
        switch (name)
        {
            case "Strength":
                total = value + _vm.Character.Strength.Bonus;
                break;
            case "Athletics":
                total = value + _vm.Character.Athletics.Bonus;
                break;
            case "Dexterity":
                total = value + _vm.Character.Dexterity.Bonus;
                break;
            case "Acrobatics":
                total = value + _vm.Character.Acrobatics.Bonus;
                break;
            case "SleightOfHand":
                total = value + _vm.Character.SleightOfHand.Bonus;
                break;
            case "Stealth":
                total = value + _vm.Character.Stealth.Bonus;
                break;
            case "Constitution":
                total = value + _vm.Character.Constitution.Bonus;
                break;
            case "Intelligence":
                total = value + _vm.Character.Intelligence.Bonus;
                break;
            case "Arcana":
                total = value + _vm.Character.Arcana.Bonus;
                break;
            case "History":
                total = value + _vm.Character.History.Bonus;
                break;
            case "Investigation":
                total = value + _vm.Character.Investigation.Bonus;
                break;
            case "Nature":
                total = value + _vm.Character.Nature.Bonus;
                break;
            case "Religion":
                total = value + _vm.Character.Religion.Bonus;
                break;
            case "Wisdom":
                total = value + _vm.Character.Wisdom.Bonus;
                break;
            case "AnimalHandling":
                total = value + _vm.Character.AnimalHandling.Bonus;
                break;
            case "Insight":
                total = value + _vm.Character.Insight.Bonus;
                break;
            case "Medicine":
                total = value + _vm.Character.Medicine.Bonus;
                break;
            case "Perception":
                total = value + _vm.Character.Perception.Bonus;
                break;
            case "Survival":
                total = value + _vm.Character.Survival.Bonus;
                break;
            case "Charisma":
                total = value + _vm.Character.Charisma.Bonus;
                break;
            case "Deception":
                total = value + _vm.Character.Deception.Bonus;
                break;
            case "Intimidation":
                total = value + _vm.Character.Intimidation.Bonus;
                break;
            case "Performance":
                total = value + _vm.Character.Performance.Bonus;
                break;
            case "Persuasion":
                total = value + _vm.Character.Persuasion.Bonus;
                break;
            default:
                break;
        }
        return total;
    }

    private void SavingButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        foreach (var item in buttonStack.Children)
        {
            var stack = item as VerticalStackLayout;
            stack.IsVisible = false;
        }
        switch (button.Text)
        {
            case "Strength":
                strengthStack.IsVisible = true;
                break;
            case "Dexterity":
                dexStack.IsVisible = true;
                break;
            case "Constitution":
                constStack.IsVisible = true;
                break;
            case "Intelligence":
                intelStack.IsVisible = true;
                break;
            case "Wisdom":
                wisStack.IsVisible = true;
                break;
            case "Charisma":
                charStack.IsVisible = true;
                break;
            default:
                break;
        }
    }
}