using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class ProficiencyEditPopup : Popup
{
	public List<string> typeList = new List<string>()
	{
		"Weapons",
		"Armor",
		"Items",
		"Languages"
	};
    public ProficiencyEditPopup()
	{
		InitializeComponent();
		ProficiencyTypePicker.ItemsSource = typeList;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		List<string> results = new List<string>();
		if (ProficiencyTypePicker.SelectedItem == null || txtName.Text == "")
		{
			return;
		}
		results.Add(ProficiencyTypePicker.SelectedItem.ToString());
		results.Add(txtName.Text);

		this.Close(results);
    }
}