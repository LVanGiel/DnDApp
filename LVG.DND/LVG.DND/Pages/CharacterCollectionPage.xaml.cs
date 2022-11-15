using LVG.DND.Models;

namespace LVG.DND.Pages;

public partial class CharacterCollectionPage : ContentPage
{
	public CharacterCollectionPage()
    {
        InitializeComponent();
        var characters = new List<Character>();
		characters.Add(new Character());
		characters.Add(new Character());

		var charocters = new CharacterCollection()
        {
            Characters = characters
        };

		BindingContext = charocters;
	}
}