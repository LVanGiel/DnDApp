using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using System.Collections.ObjectModel;

namespace LVG.DND.ViewModel
{
    public partial class ImageButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        public string title;
        [ObservableProperty]
        public string imageUrl;
        [ObservableProperty]
        public Command imgBtnClicked;

        public ImageButtonViewModel()
        {

        }
    }
}
