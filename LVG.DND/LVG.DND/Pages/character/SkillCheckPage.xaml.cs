using LVG.DND.ViewModel.characterViewModels;

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
		StrengthBtn.ButtonStat = _vm.Character.Strength.BonusText;
        AthleticsBtn.ButtonStat = _vm.Character.Athletics.BonusText;

        DexterityBtn.ButtonStat = _vm.Character.Dexterity.BonusText;
        AcrobaticsBtn.ButtonStat = _vm.Character.Acrobatics.BonusText;
        SleightOfHandBtn.ButtonStat = _vm.Character.SleightOfHand.BonusText;
        StealthBtn.ButtonStat = _vm.Character.Stealth.BonusText;

        ConstitutionBtn.ButtonStat = _vm.Character.Constitution.BonusText;

        IntelligenceBtn.ButtonStat = _vm.Character.Intelligence.BonusText;
        ArcanaBtn.ButtonStat = _vm.Character.Arcana.BonusText;
        HistoryBtn.ButtonStat = _vm.Character.History.BonusText;
        InvestigationBtn.ButtonStat = _vm.Character.Investigation.BonusText;
        NatureBtn.ButtonStat = _vm.Character.Nature.BonusText;
        ReligionBtn.ButtonStat = _vm.Character.Religion.BonusText;

        WisdomBtn.ButtonStat = _vm.Character.Wisdom.BonusText;
        AnimalHandlingBtn.ButtonStat = _vm.Character.AnimalHandling.BonusText;
        InsightBtn.ButtonStat = _vm.Character.Insight.BonusText;
        MedicineBtn.ButtonStat = _vm.Character.Medicine.BonusText;
        PerceptionBtn.ButtonStat = _vm.Character.Perception.BonusText;
        SurvivalBtn.ButtonStat = _vm.Character.Survival.BonusText;

        CharismaBtn.ButtonStat = _vm.Character.Charisma.BonusText;
        DeceptionBtn.ButtonStat = _vm.Character.Deception.BonusText;
        IntimidationBtn.ButtonStat = _vm.Character.Intimidation.BonusText;
        PerformanceBtn.ButtonStat = _vm.Character.Performance.BonusText;
        PersuasionBtn.ButtonStat = _vm.Character.Persuasion.BonusText;
    }
}