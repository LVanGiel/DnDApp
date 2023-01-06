using LVG.DND.AppConstants;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;
using Microsoft.Maui.Controls;

namespace LVG.DND.Views.characterviews;

public partial class CharacterSkillsAndAbilitiesView : ContentView
{
    BaseCharacterViewModel _vm;
    Streaming stream = new Streaming();
    bool loaded = false;

    public CharacterSkillsAndAbilitiesView(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext= _vm;
        InitializeComponent();
        bool succesful = false;
        while (succesful)
        {
            try
            {
                InitializeCheckboxes();
                succesful = true;
            }
            catch (Exception)
            {
                continue;
            }
        }
        loaded = true;
    }
    private bool ProficiencyEnabled(Skill skill)
    {
        if (skill.ProficiencyBonus > 0)
        {
            return true;
        }
        return false;
    }
    private void InitializeCheckboxes()
    {
        checkAcrobatics.IsChecked = ProficiencyEnabled(_vm.Character.Acrobatics);
        checkAnimalHandling.IsChecked = ProficiencyEnabled(_vm.Character.AnimalHandling);
        checkArcana.IsChecked = ProficiencyEnabled(_vm.Character.Arcana);
        checkAthletics.IsChecked = ProficiencyEnabled(_vm.Character.Athletics);
        checkDeception.IsChecked = ProficiencyEnabled(_vm.Character.Deception);
        checkHistory.IsChecked = ProficiencyEnabled(_vm.Character.Acrobatics);

        checkInsight.IsChecked = ProficiencyEnabled(_vm.Character.Insight);
        checkIntimidation.IsChecked = ProficiencyEnabled(_vm.Character.Intimidation);
        checkInvestigation.IsChecked = ProficiencyEnabled(_vm.Character.Investigation);
        checkMedicine.IsChecked = ProficiencyEnabled(_vm.Character.Medicine);
        checkNature.IsChecked = ProficiencyEnabled(_vm.Character.Nature);
        checkPerception.IsChecked = ProficiencyEnabled(_vm.Character.Perception);

        checkPerformance.IsChecked = ProficiencyEnabled(_vm.Character.Performance);
        checkPersuasion.IsChecked = ProficiencyEnabled(_vm.Character.Persuasion);
        checkReligion.IsChecked = ProficiencyEnabled(_vm.Character.Religion);
        checkSleightOfHand.IsChecked = ProficiencyEnabled(_vm.Character.SleightOfHand);
        checkStealth.IsChecked = ProficiencyEnabled(_vm.Character.Stealth);
        checkSurvival.IsChecked = ProficiencyEnabled(_vm.Character.Survival);

        checkStrength.IsChecked = ProficiencyEnabled(_vm.Character.StrengthSave);
        checkDexterity.IsChecked = ProficiencyEnabled(_vm.Character.DexteritySave);
        checkConstitution.IsChecked = ProficiencyEnabled(_vm.Character.ConstitutionSave);
        checkIntelligence.IsChecked = ProficiencyEnabled(_vm.Character.IntelligenceSave);
        checkWisdom.IsChecked = ProficiencyEnabled(_vm.Character.WisdomSave);
        checkCharisma.IsChecked = ProficiencyEnabled(_vm.Character.CharismaSave);
    }
    private void EnableEntry(Entry control)
    {
        control.IsEnabled = !control.IsEnabled;
    }
    private void EnableCheck(CheckBox control)
    {
        control.IsEnabled = !control.IsEnabled;
    }
    private void EnableEdit()
    {
        EnableEntry(txtStrengthLevel);
        EnableEntry(txtDexterityLevel);
        EnableEntry(txtConstitutionLevel);
        EnableEntry(txtIntelligenceLevel);
        EnableEntry(txtWisdomLevel);
        EnableEntry(txtCharismaLevel);

        EnableEntry(txtProficiencyBonus);

        EnableCheck(checkAcrobatics);
        EnableCheck(checkAnimalHandling);
        EnableCheck(checkArcana);
        EnableCheck(checkAthletics);
        EnableCheck(checkDeception);
        EnableCheck(checkHistory);

        EnableCheck(checkInsight);
        EnableCheck(checkIntimidation);
        EnableCheck(checkInvestigation);
        EnableCheck(checkMedicine);
        EnableCheck(checkNature);
        EnableCheck(checkPerception);

        EnableCheck(checkPerformance);
        EnableCheck(checkPersuasion);
        EnableCheck(checkReligion);
        EnableCheck(checkSleightOfHand);
        EnableCheck(checkStealth);
        EnableCheck(checkSurvival);

        EnableCheck(checkStrength);
        EnableCheck(checkDexterity);
        EnableCheck(checkConstitution);
        EnableCheck(checkIntelligence);
        EnableCheck(checkWisdom);
        EnableCheck(checkCharisma);

    }
    private void RefreshBindings()
    {
        //Death Saves
        txtStrengthSaveBonus.Text = _vm.Character.StrengthSave.BonusText;
        txtDexteritySaveBonus.Text = _vm.Character.DexteritySave.BonusText;
        txtConstitutionSaveBonus.Text = _vm.Character.ConstitutionSave.BonusText;
        txtIntelligenceSaveBonus.Text = _vm.Character.IntelligenceSave.BonusText;
        txtWisdomSaveBonus.Text = _vm.Character.WisdomSave.BonusText;
        txtCharismaSaveBonus.Text = _vm.Character.CharismaSave.BonusText;

        //Ability Scores
        txtStrengthBonus.Text = _vm.Character.Strength.BonusText;
        txtDexterityBonus.Text = _vm.Character.Dexterity.BonusText;
        txtConstitutionBonus.Text = _vm.Character.Constitution.BonusText;
        txtIntelligenceBonus.Text = _vm.Character.Intelligence.BonusText;
        txtCharismaBonus.Text = _vm.Character.Charisma.BonusText;
        txtWisdomBonus.Text = _vm.Character.Wisdom.BonusText;

        //Skills
        txtAcrobaticsBonus.Text = _vm.Character.Acrobatics.BonusText;
        txtAnimalHandlingBonus.Text = _vm.Character.AnimalHandling.BonusText;
        txtArcanaBonus.Text = _vm.Character.Arcana.BonusText;
        txtAthleticsBonus.Text = _vm.Character.Athletics.BonusText;
        txtDeceptionBonus.Text = _vm.Character.Deception.BonusText;

        txtHistoryBonus.Text = _vm.Character.History.BonusText;
        txtInsightBonus.Text = _vm.Character.Insight.BonusText;
        txtIntimidationBonus.Text = _vm.Character.Intimidation.BonusText;
        txtInvestigationBonus.Text = _vm.Character.Investigation.BonusText;
        txtMedicineBonus.Text = _vm.Character.Medicine.BonusText;

        txtNatureBonus.Text = _vm.Character.Nature.BonusText;
        txtPerceptionBonus.Text = _vm.Character.Perception.BonusText;
        txtPerformanceBonus.Text = _vm.Character.Performance.BonusText;
        txtPersuasionBonus.Text = _vm.Character.Persuasion.BonusText;
        txtReligionBonus.Text = _vm.Character.Religion.BonusText;

        txtSleightOfHandBonus.Text = _vm.Character.SleightOfHand.BonusText;
        txtStealthBonus.Text = _vm.Character.Stealth.BonusText;
        txtSurvivalBonus.Text = _vm.Character.Survival.BonusText;
    }
    private int CheckCheckbox(CheckBox box)
    {
        if (box.IsChecked)
        {
            return _vm.Character.ProficiencyBonus;
        }
        return 0;
    }

    #region events
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (txtStrengthLevel.IsEnabled)
        {
            _vm.Character.UpdateSkills();
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
    private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!loaded)
        {
            return;
        }
        _vm.Character.Acrobatics.ProficiencyBonus = CheckCheckbox(checkAcrobatics);
        _vm.Character.AnimalHandling.ProficiencyBonus = CheckCheckbox(checkAnimalHandling);
        _vm.Character.Arcana.ProficiencyBonus = CheckCheckbox(checkArcana);
        _vm.Character.Athletics.ProficiencyBonus = CheckCheckbox(checkAthletics);
        _vm.Character.Deception.ProficiencyBonus = CheckCheckbox(checkDeception);

        _vm.Character.History.ProficiencyBonus = CheckCheckbox(checkHistory);
        _vm.Character.Insight.ProficiencyBonus = CheckCheckbox(checkInsight);
        _vm.Character.Intimidation.ProficiencyBonus = CheckCheckbox(checkIntimidation);
        _vm.Character.Investigation.ProficiencyBonus = CheckCheckbox(checkInvestigation);
        _vm.Character.Medicine.ProficiencyBonus = CheckCheckbox(checkMedicine);

        _vm.Character.Nature.ProficiencyBonus = CheckCheckbox(checkNature);
        _vm.Character.Perception.ProficiencyBonus = CheckCheckbox(checkPerception);
        _vm.Character.Performance.ProficiencyBonus = CheckCheckbox(checkPerformance);
        _vm.Character.Persuasion.ProficiencyBonus = CheckCheckbox(checkPersuasion);
        _vm.Character.Religion.ProficiencyBonus = CheckCheckbox(checkReligion);

        _vm.Character.SleightOfHand.ProficiencyBonus = CheckCheckbox(checkSleightOfHand);
        _vm.Character.Stealth.ProficiencyBonus = CheckCheckbox(checkStealth);
        _vm.Character.Survival.ProficiencyBonus = CheckCheckbox(checkSurvival);

        _vm.Character.StrengthSave.ProficiencyBonus = CheckCheckbox(checkStrength);
        _vm.Character.DexteritySave.ProficiencyBonus = CheckCheckbox(checkDexterity);
        _vm.Character.ConstitutionSave.ProficiencyBonus = CheckCheckbox(checkConstitution);
        _vm.Character.IntelligenceSave.ProficiencyBonus = CheckCheckbox(checkIntelligence);
        _vm.Character.WisdomSave.ProficiencyBonus = CheckCheckbox(checkWisdom);
        _vm.Character.CharismaSave.ProficiencyBonus = CheckCheckbox(checkCharisma);
    }
    #endregion


}