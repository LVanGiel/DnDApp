using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterStatsView : ContentView
{
	CharacterStatsViewModel _vm;
    Streaming _stream = new Streaming();
    const string edit = "Edit";
    const string confirm = "Confirm";
	public CharacterStatsView(CharacterStatsViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
		InitializeComponent();
	}

	private async Task<string> EnableEdit(int stat)
	{
		bool isEnabled = false;
		switch (stat)
		{
			case 0:
				txtArmor.IsEnabled = !txtArmor.IsEnabled;
				isEnabled = txtArmor.IsEnabled;
                break;
            case 1:
                txtInitiative.IsEnabled = !txtInitiative.IsEnabled;
                isEnabled = txtInitiative.IsEnabled;
                break;
            case 2:
                txtSpeed.IsEnabled = !txtSpeed.IsEnabled;
                isEnabled = txtSpeed.IsEnabled;
                break;
            case 3:
                txtMaxHp.IsEnabled = !txtMaxHp.IsEnabled;
                isEnabled = txtMaxHp.IsEnabled;
                break;
            case 4:
                txtHp.IsEnabled = !txtHp.IsEnabled;
                isEnabled = txtHp.IsEnabled;
                break;
            case 5:
                txtLevel.IsEnabled = !txtLevel.IsEnabled;
                isEnabled = txtLevel.IsEnabled;
                break;
            default:
				break;
		}
		if (isEnabled)
		{
            return confirm;
		}
		else
		{
            await _stream.SaveCharacter(_vm.character);
            return edit;
        }
	}

    #region Events

    private async void btnArmor_Clicked(object sender, EventArgs e)
	{
		(sender as Button).Text = await EnableEdit(0);

    }

	private async void btnInitiative_Clicked(object sender, EventArgs e)
	{
        (sender as Button).Text = await EnableEdit(1);
    }

	private async void btnSpeed_Clicked(object sender, EventArgs e)
	{
        (sender as Button).Text = await EnableEdit(2);
    }

	private async void btnMaxHp_Clicked(object sender, EventArgs e)
	{
        (sender as Button).Text = await EnableEdit(3);
    }
    private async void btnLevel_Clicked(object sender, EventArgs e)
    {
        (sender as Button).Text = await EnableEdit(5);
    }
    private async void txtHp_Completed(object sender, EventArgs e)
    {
        await _stream.SaveCharacter(_vm.character);
    }
    #endregion

}