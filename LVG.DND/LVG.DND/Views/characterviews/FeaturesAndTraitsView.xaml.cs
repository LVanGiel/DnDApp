using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Views.characterviews;

public partial class FeaturesAndTraitsView : ContentView
{
    BaseCharacterViewModel _vm;
    Streaming _stream = new Streaming();
    public FeaturesAndTraitsView(BaseCharacterViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
	}
    private void ReloadList()
    {
        traitList.ItemsSource = null;
        traitList.ItemsSource = _vm.Character.Traits;
    }
    private void traitList_ItemSelected(object sender, EventArgs e)
    {
        
    }
    private async void RemoveButton_Clicked(object sender, EventArgs e)
    {
        var neighbour = ((sender as Button).Parent as Grid).Children[0] as Entry;
        _vm.Character.Traits.Remove(_vm.Character.Traits.FirstOrDefault(x => x.Name == neighbour.Text));
        await _stream.SaveCharacter(_vm.Character);
        ReloadList();
    }
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var popup = new AddTraitPopup();
        Trait popupResult = await (this.Parent.Parent.Parent as ContentPage).ShowPopupAsync(popup) as Trait;
        if (popupResult != null)
        {
            _vm.Character.Traits.Add(popupResult);
            await _stream.SaveCharacter(_vm.Character);
            ReloadList();
        }
    }
}