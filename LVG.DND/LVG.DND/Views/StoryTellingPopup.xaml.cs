using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class StoryTellingPopup : Popup
{
    Character _character;
	public StoryTellingPopup(string title)
	{
		InitializeComponent();
        Titletxt.Text = title;
        AddCharacter();
    }
    private async void
    private async void AddCharacter()
    {
        _character = await (new Character()).GetActiveCharacter();
    }
    private void EditButton_Clicked(object sender, EventArgs e)
    {
        if (Contenttxt.IsEnabled)
        {
            (sender as Button).Text = "Edit";
        }
        else
        {
            (sender as Button).Text = "OK";
            Savebtn.IsVisible = true;
        }
        Contenttxt.IsEnabled = !Contenttxt.IsEnabled;
    }
    private void SaveButton_Clicked(Object sender, EventArgs e)
    {
        this.Close(Contenttxt.Text);
    }
}