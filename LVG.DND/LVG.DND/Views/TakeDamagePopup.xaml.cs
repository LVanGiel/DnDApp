using CommunityToolkit.Maui.Views;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class TakeDamagePopup : Popup
{
	public TakeDamagePopup(Character character)
	{
		InitializeComponent();
        txtHealth.Text = "0";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (txtHealth.Text == null)
		{
			return;
		}
		string result;
		result = txtHealth.Text == null ? "0" : txtHealth.Text;

        this.Close(result);
    }
}