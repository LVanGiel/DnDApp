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
    }

    private void RollChoiceButton_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button).Text == "Roll in app") 
        {
            RollInApp.IsVisible = true;
        }
        else
        {
            InputStack.IsVisible = true;
        }
        ((sender as Button).Parent as VerticalStackLayout).IsVisible = false;
    }
}