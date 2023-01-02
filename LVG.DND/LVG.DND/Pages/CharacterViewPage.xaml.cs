using LVG.DND.AppConstants;
using LVG.DND.ViewModel;

namespace LVG.DND.Pages;

[QueryProperty(nameof(Page), nameof(Page))]
public partial class CharacterViewPage : ContentPage
{
    CharacterViewConstants _constants = new CharacterViewConstants();
    string page = "";
    public string Page { get { return page; } set
        {
            page = Uri.UnescapeDataString(value ?? string.Empty);
            OnPropertyChanged();
            AddToStack();
        } }
    public ContentView SelectedPage { get; set; }

    public CharacterViewPage()
	{
        InitializeComponent();
    }
    private async void AddToStack()
    {
        SelectedPage = await _constants.GetCorrectPage(Page);
        CharViewStack.Add(SelectedPage);
    }

}