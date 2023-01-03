using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterSkillsAndAbilitiesView : ContentView
{
    CharacterSkillsAndAbilityscoresViewModel _vm;
    Streaming stream = new Streaming();

    public CharacterSkillsAndAbilitiesView(CharacterSkillsAndAbilityscoresViewModel vm)
	{
        _vm = vm;
        BindingContext= _vm;
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (txtStrengthLevel.IsEnabled)
        {
            UpdateSkills();
            RefreshBindings();
            await stream.SaveCharacter(_vm.Character);
            EnableEdit();
            (sender as Button).Text = "Edit";
        }
        else
        {
            EnableEdit();
            (sender as Button).Text = "Save";
        }
    }
    private void EnableEdit()
    {
        txtStrengthLevel.IsEnabled = !txtStrengthLevel.IsEnabled;
        txtDexterityLevel.IsEnabled = !txtDexterityLevel.IsEnabled;
        txtConstitutionLevel.IsEnabled = !txtConstitutionLevel.IsEnabled;
        txtIntelligenceLevel.IsEnabled = !txtIntelligenceLevel.IsEnabled;
        txtWisdomLevel.IsEnabled = !txtWisdomLevel.IsEnabled;
        txtCharismaLevel.IsEnabled = !txtCharismaLevel.IsEnabled;
    }
    private void UpdateSkills()
    {
        _vm.Character.UpdateAbilityScore(_vm.Character.Strength);
        _vm.Character.UpdateAbilityScore(_vm.Character.Constitution);
        _vm.Character.UpdateAbilityScore(_vm.Character.Dexterity);
        _vm.Character.UpdateAbilityScore(_vm.Character.Intelligence);
        _vm.Character.UpdateAbilityScore(_vm.Character.Wisdom);
        _vm.Character.UpdateAbilityScore(_vm.Character.Charisma);
    }
    private void RefreshBindings()
    {
        //Ability Scores
        txtStrengthBonus.Text = _vm.Character.Strength.BonusText;
        txtDexterityBonus.Text = _vm.Character.Dexterity.BonusText;
        txtConstitutionBonus.Text = _vm.Character.Constitution.BonusText;
        txtIntelligenceBonus.Text = _vm.Character.Intelligence.BonusText;
        txtCharismaBonus.Text = _vm.Character.Charisma.BonusText;
        txtWisdomBonus.Text = _vm.Character.Wisdom.BonusText;

        //Skills
        txtAcrobaticsBonus.Text = _vm.Character.Skills.Acrobatics.BonusText;
        txtAnimalHandlingBonus.Text = _vm.Character.Skills.AnimalHandling.BonusText;
        txtArcanaBonus.Text = _vm.Character.Skills.Arcana.BonusText;
        txtAthleticsBonus.Text = _vm.Character.Skills.Athletics.BonusText;
        txtDeceptionBonus.Text = _vm.Character.Skills.Deception.BonusText;

        txtHistoryBonus.Text = _vm.Character.Skills.History.BonusText;
        txtInsightBonus.Text = _vm.Character.Skills.Insight.BonusText;
        txtIntimidationBonus.Text = _vm.Character.Skills.Intimidation.BonusText;
        txtInvestigationBonus.Text = _vm.Character.Skills.Investigation.BonusText;
        txtMedicineBonus.Text = _vm.Character.Skills.Medicine.BonusText;

        txtNatureBonus.Text = _vm.Character.Skills.Nature.BonusText;
        txtPerceptionBonus.Text = _vm.Character.Skills.Perception.BonusText;
        txtPerformanceBonus.Text = _vm.Character.Skills.Performance.BonusText;
        txtPersuasionBonus.Text = _vm.Character.Skills.Persuasion.BonusText;
        txtReligionBonus.Text = _vm.Character.Skills.Religion.BonusText;

        txtSleightOfHandBonus.Text = _vm.Character.Skills.SleightOfHand.BonusText;
        txtStealthBonus.Text = _vm.Character.Skills.Stealth.BonusText;
        txtSurvivalBonus.Text = _vm.Character.Skills.Survival.BonusText;
    }
}