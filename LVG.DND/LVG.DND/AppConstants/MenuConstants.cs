using LVG.DND.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVG.DND.AppConstants
{
    public class MenuConstants
    {
        public FlyoutItem flyoutItem;
        public MenuConstants()
        {
            GetFlyout();
        }
        public void GetFlyout()
        {
            flyoutItem = new FlyoutItem()
            {
                Title = "Test",
                Route = "Test",
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    new ShellContent
                    {
                        Title="Test1",
                        ContentTemplate = new DataTemplate(typeof(DndDice))
                    },
                    new ShellContent
                    {
                        Title="Test2",
                        ContentTemplate = new DataTemplate(typeof(DndDice))
                    }
                }
            };
        }
    }
}
