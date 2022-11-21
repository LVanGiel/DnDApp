using CommunityToolkit.Mvvm.ComponentModel;

namespace LVG.DND.ViewModel
{
    public partial class AbilityScoresViewModel : ObservableObject
    {
        [ObservableProperty]
        int strength;
        [ObservableProperty]
        int dexterity;
        [ObservableProperty]
        int constitution;
        [ObservableProperty]
        int intelligence;
        [ObservableProperty]
        int wisdom;
        [ObservableProperty]
        int charisma;
    }
}
