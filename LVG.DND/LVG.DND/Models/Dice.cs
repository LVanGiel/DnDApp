
using CommunityToolkit.Mvvm.ComponentModel;

namespace LVG.DND.Models
{
    public partial class Dice : ObservableObject
    {
        [ObservableProperty]
        string diceImageUrl;
        [ObservableProperty]
        int diceSize;
        [ObservableProperty]
        int number;

        public Dice()
        {
        }

        private Random random = new Random();

        private void SetImage(int size)
        {
            string diceImageStyle = "dice_red";
            string diceImageType = ".png";
            DiceImageUrl = diceImageStyle + diceSize + diceImageType;

        }
        public void ChangeSize(int size)
        {
            Number = size;
            DiceSize = size;
            SetImage(diceSize);
        }
        public async Task RollDice(int max) { 
    
            int x = (diceSize == 10 || diceSize == 100) ? 0 : 1;

            for (int i = 0; i < 10; i++)
            {
                Number = random.Next(max) + x;
                await Task.Delay(100);
            }
        }
    }
    
}
