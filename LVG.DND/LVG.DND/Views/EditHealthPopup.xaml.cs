using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class EditHealthPopup : Popup
{
	public EditHealthPopup()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (txtName.Text == null || txtDescription.Text == null)
		{
			return;
		}
		var result = new Trait();
		result.Name = txtName.Text;
		result.Description = txtDescription.Text;

		this.Close(result);
    }
}