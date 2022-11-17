using LVG.DND.Models;
using System.Collections.ObjectModel;

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
		var characteres = new ObservableCollection<Character>();
		characteres.Add(new Character() {Id = new Guid() });
        characteres.Add(new Character() {Id = new Guid() });
		var characters = new CharacterCollection();
		characters.Characters = characteres;
		characters.Position = 1;
		BindingContext = characters;
    }
}