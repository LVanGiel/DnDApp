using LVG.DND.Models;
using LVG.DND.Models.CharacterChoices;
using LVG.DND.ViewModel;
using Newtonsoft.Json;

namespace LVG.DND.Pages.charcreation;
public partial class ClassSelector : ContentPage
{
    public CharCreateViewModel _vm;
    List<string> unSelectedSkills = new List<string>();
    List<string> selectedSkills = new List<string>();
    int skillProficienciesCount = 0;
    public ClassSelector(CharCreateViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
        this.Loaded += new EventHandler(This_Loaded);

    }
    private void FillClassNames()
    {
        List<string> classNames = new List<string>();
        classNames.Clear();
        foreach (CharClass charclass in _vm.Classes)
        {
            classNames.Add(charclass.Name);
        }
        ClassPicker.ItemsSource = classNames;
        ClassPicker.ItemsSource = ClassPicker.GetItemsAsArray();
        ClassPicker.SelectedIndex = 0;
    }
    private void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string className = (sender as Picker).SelectedItem as string;
        CharClass activeClass = _vm.Classes.FirstOrDefault(x => x.Name == className);

        var chosenClass = new ClassChoice();
        chosenClass.ConvertCharClass(activeClass);

        _vm.Character.AddClass(chosenClass);
        ClassSkillsProficienciesList.ItemsSource = activeClass.SkillProficiencies;
        ClassSelectedSkillsProficienciesList.ItemsSource = null;
        unSelectedSkills = activeClass.SkillProficiencies;
        selectedSkills = null;
        SkillProfTxt.Text = $"Choose {activeClass.SkillProficienciesCount} skill proficiencies";
        skillProficienciesCount = activeClass.SkillProficienciesCount;
    }
    private void This_Loaded(object sender, EventArgs e)
    {
        FillClassNames();
    }

    private void ClassSkillsProficienciesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedSkills = selectedSkills == null ? new List<string>() : selectedSkills;
        if (selectedSkills.Count >= skillProficienciesCount)
        {
            unSelectedSkills.Add(selectedSkills[selectedSkills.Count - 1]);
            selectedSkills.RemoveAt(0);
        }
        selectedSkills.Add(ClassSkillsProficienciesList.SelectedItem as string);
        unSelectedSkills.Remove(ClassSkillsProficienciesList.SelectedItem as string);

        ClassSkillsProficienciesList.ItemsSource = null;
        ClassSelectedSkillsProficienciesList.ItemsSource = null;

        ClassSkillsProficienciesList.ItemsSource = unSelectedSkills;
        ClassSelectedSkillsProficienciesList.ItemsSource = selectedSkills;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        AbilityScoreCreator AbilityScorePage = new AbilityScoreCreator(_vm);
        await Navigation.PushAsync(AbilityScorePage);
    }
}