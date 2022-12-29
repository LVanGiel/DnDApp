using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using System.Collections.ObjectModel;

namespace LVG.DND.ViewModel
{
    public partial class DndDiceViewModel : ObservableObject
    {

        static readonly int[] diceTypes = { 4, 6, 8, 10, 12, 20, 100 };

        [ObservableProperty]
        ObservableCollection<Dice> dices = new ObservableCollection<Dice>();

        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        int number;

        [ObservableProperty]
        int maxRoll;

        [ObservableProperty]
        Dice mainDice;

        public DndDiceViewModel()
        {
            mainDice = new Dice();
        }

        public void LoadDiceMenu()
        {
            foreach (var dice in diceTypes)
            {
                AddMenuDice(dice);
            }
        }

        public void AddMenuDice(int diceSize)
        {
            Dice newDice = new Dice();
            newDice.ChangeSize(diceSize);
            dices.Add(newDice);
        }

        public void AddMainDice(int diceSize = 20)
        {
            mainDice.ChangeSize(diceSize);
        }

        public async void RollDice(int max)
        {
            await mainDice.RollDice(max);
        }

    }
}
