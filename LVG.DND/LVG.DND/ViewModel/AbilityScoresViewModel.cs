using CommunityToolkit.Mvvm.ComponentModel;

namespace LVG.DND.ViewModel
{
    public partial class AbilityScoresViewModel : ObservableObject
    {
        [ObservableProperty]
        List<int> diceScores = new List<int>();
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
