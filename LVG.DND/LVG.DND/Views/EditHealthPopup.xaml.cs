using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class EditHealthPopup : Popup
{
	public EditHealthPopup(Character character)
	{
		InitializeComponent();
        lblCurrentHealth.Text = character.CurrentHealth.ToString();
        lblTempHealth.Text = character.TemporaryHealth.ToString();
        lblMaxHealth.Text = character.MaxHealth.ToString();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (txtHealth.Text == null || txtTempHealth.Text == null)
		{
			return;
		}
		var result = new List<string>();
		if (txtHealth.Text == null)
		{
			txtHealth.Text = "0";
        }
        if (txtTempHealth.Text == null)
        {
            txtTempHealth.Text = "0";
        }
        if (txtMaxHealth.Text == null)
        {
            txtMaxHealth.Text = "0";
        }
        result.Add(txtHealth.Text);
        result.Add(txtTempHealth.Text);
        result.Add(txtMaxHealth.Text);

        this.Close(result);
    }
}