using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.Models.basemodel;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Pages.character;

public partial class InventoryPage : ContentPage
{
    BaseCharacterViewModel _vm;
    Streaming _stream = new Streaming();
    bool loaded = false;
    public InventoryPage(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
		InitializeComponent();
        loaded = true;
    }
    private void ReloadBindings()
    {
        itemList.ItemsSource = null;
        BagOfHoldingItemList.ItemsSource = null;
        BagOfHoldingItemList.ItemsSource = _vm.Character.BagOfHoldingItems;
        itemList.ItemsSource = _vm.Character.Items;
    }
    private async void RemoveButton_Clicked(object sender, EventArgs e)
    {
        var senderParent = (sender as Button).Parent as Grid;
        var bagOfHoldingLabel = senderParent.Children[0];
        if (bagOfHoldingLabel.GetType() == typeof(Label))
        {
            var nameTxt = senderParent.Children[1] as Entry;
            _vm.Character.BagOfHoldingItems.Remove(_vm.Character.BagOfHoldingItems.First(x => x.Name == nameTxt.Text));
        }
        else
        {
            _vm.Character.Items.Remove(_vm.Character.Items.First(x => x.Name == (bagOfHoldingLabel as Entry).Text));
        }
        await _vm.Character.SaveCharacter(_vm.Character);
        ReloadBindings();
    }
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (txtNameAdd.Text == "" || txtNameAdd.Text == null)
        {
            return;
        }
        var item = new Item();
        item.Name = txtNameAdd.Text;
        //item.Value = txtValueAdd.Text;
        _vm.Character.Items.Add(item);
        await _vm.Character.SaveCharacter(_vm.Character);
        ReloadBindings();
    }
    private async void AddBagOfHoldingButton_Clicked(object sender, EventArgs e)
    {
        if (txtBagOfHoldingNameAdd.Text == "" || txtBagOfHoldingNameAdd.Text == null)
        {
            return;
        }
        if (_vm.Character.BagOfHoldingItems == null)
        {
            _vm.Character.BagOfHoldingItems = new List<Item>();
        }
        if (_vm.Character.BagOfHoldingMoneyPouch == null)
        {
            _vm.Character.BagOfHoldingMoneyPouch = new MoneyBag();
        }

        var item = new Item();
        item.Name = txtBagOfHoldingNameAdd.Text;
        _vm.Character.BagOfHoldingItems.Add(item);
        await _vm.Character.SaveCharacter(_vm.Character);
        ReloadBindings();
    }

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (loaded)
        {
            await _vm.Character.SaveCharacter(_vm.Character);
        }
         
    }

    private async void btnBagOfHolding_Clicked(object sender, EventArgs e)
    {
        if (_vm.Character.HasBagOfHolding)
        {
            (sender as Button).Text = "Add Bag of holding";
        }
        else
        {
            (sender as Button).Text = "Remove Bag of holding";
        }
        _vm.Character.HasBagOfHolding = !_vm.Character.HasBagOfHolding;
        BagOfHoldingStack.IsVisible = _vm.Character.HasBagOfHolding;
        await _vm.Character.SaveCharacter(_vm.Character);
    }
}