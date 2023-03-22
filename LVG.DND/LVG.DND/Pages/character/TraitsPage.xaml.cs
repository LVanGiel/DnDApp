using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel.characterViewModels;

namespace LVG.DND.Pages.character;

public partial class TraitsPage : ContentPage
{
    BaseCharacterViewModel _vm;
    public TraitsPage(BaseCharacterViewModel vm)
	{
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
	}
}