using LVG.DND.ViewModel;
using System.Windows.Input;

namespace LVG.DND.Views.general;

public partial class ImageButtonView : ContentView
{

    private ImageButtonViewModel _viewModel;
    public ImageButtonView(ImageButtonViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }
    public ImageButtonView(string title, string imageUrl, Command command)
    {
        InitializeComponent();

        var vm = new ImageButtonViewModel();
        vm.title = title;
        vm.imageUrl=imageUrl;
        vm.imgBtnClicked = command;

        BindingContext = vm;
        _viewModel = vm;

    }
}