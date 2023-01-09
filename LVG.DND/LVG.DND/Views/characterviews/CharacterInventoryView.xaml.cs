using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class CharacterInventoryView : ContentView
{
    BaseCharacterViewModel _vm;
    Streaming _stream = new Streaming();
    public CharacterInventoryView(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
		InitializeComponent();
	}
    private void ReloadBindings()
    {
        itemList.ItemsSource = null;
        itemList.ItemsSource = _vm.Character.Items;
    }

	private void RemoveButton_Clicked(object sender, EventArgs e)
	{

	}
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (txtNameAdd.Text == "" || txtNameAdd.Text == null)
        {
            return;
        }
        var item = new Item();
        item.Name = txtNameAdd.Text;
        item.Value = txtValueAdd.Text;
        _vm.Character.Items.Add(item);
        await _vm.Character.SaveCharacter(_vm.Character);
        ReloadBindings();
    }

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
         await _vm.Character.SaveCharacter(_vm.Character);
    }
}