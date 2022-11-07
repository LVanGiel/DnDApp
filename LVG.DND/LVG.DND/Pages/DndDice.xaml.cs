using CommunityToolkit.Maui.Views;
using LVG.DND.ViewModel;
using LVG.DND.Views;

namespace LVG.DND.Pages;

public partial class DndDice : ContentPage
{
	
	
	private DndDiceViewModel _viewModel;
	public DndDice(DndDiceViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		_viewModel = vm;
        Init();
	}
	private void Init()
	{
        _viewModel.LoadDiceMenu();
        _viewModel.AddMainDice(20);
    }

	private void btnDiceMenu_Clicked(object sender, EventArgs e)
	{
		Button btnDice = sender as Button;

        int maxValue;
		if (int.TryParse(btnDice.Text, out maxValue))
		{
            var popup = new DicePopup(maxValue);

            this.ShowPopupAsync(popup);
		}
    }
    private void btnDice_Clicked(object sender, EventArgs e)
    {
        Button btnDice = sender as Button;
		
        _viewModel.RollDice(btnDice.ZIndex);
    }
}