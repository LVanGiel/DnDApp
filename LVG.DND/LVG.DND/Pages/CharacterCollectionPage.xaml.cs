using LVG.DND.Models;

namespace LVG.DND.Pages;

public partial class CharacterCollectionPage : ContentPage
{
	public CharacterCollectionPage()
	{
		InitializeComponent();
		init();
	}
	void init()
	{
		var characteres = new List<Character>();
		characteres.Add(new Character());
        characteres.Add(new Character());
		BindingContext = this;
    }
}