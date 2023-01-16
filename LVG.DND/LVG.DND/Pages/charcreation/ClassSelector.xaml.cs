using LVG.DND.Models;
using LVG.DND.ViewModel;
using Newtonsoft.Json;

namespace LVG.DND.Pages.charcreation;
public partial class ClassSelector : ContentPage
{
    public ClassSelectorViewModel _vm;
    public ClassSelector()
    {
        InitializeComponent();
        _vm = new ClassSelectorViewModel();
        Init();
        BindingContext = _vm;
        
    }
    private async void Init()
    {
        var basepath = FileSystem.Current.CacheDirectory;
        Character character = new Character();
        var pathString = Path.Combine(basepath, "temporaryCharacter.txt");
        var characterString = await File.ReadAllTextAsync(pathString);
        _vm.Character = JsonConvert.DeserializeObject<Character>(characterString);
    }
    private void ClassCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //_vm.Character.Class = e.CurrentSelection.FirstOrDefault() as CharClass;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}