using CommunityToolkit.Maui.Views;
using LVG.DND.ViewModel;
using LVG.DND.Views;

namespace LVG.DND.Views.characterviews;

public partial class CharacterStorytellingView : ContentView
{
	public CharacterStorytellingView()
	{
		InitializeComponent();
	}
	private async Task<string> OpenPopup(string title, string description)
	{
        var popup = new StoryTellingPopup(title, description);
		return (await (this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup)) as string;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}