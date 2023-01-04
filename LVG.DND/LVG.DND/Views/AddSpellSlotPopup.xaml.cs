using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class AddSpellSlotPopup : Popup
{
	public AddSpellSlotPopup(int lvl1, int lvl2, int lvl3, int lvl4, int lvl5, int lvl6, int lvl7, int lvl8, int lvl9)
	{
        InitializeComponent();

        Lvl1.Text = lvl1.ToString();
        Lvl2.Text = lvl2.ToString();
        Lvl3.Text = lvl3.ToString();
        Lvl4.Text = lvl4.ToString();
        Lvl5.Text = lvl5.ToString();
        Lvl6.Text = lvl6.ToString();
        Lvl7.Text = lvl7.ToString();
        Lvl8.Text = lvl8.ToString();
        Lvl9.Text = lvl9.ToString();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        List<int> slots = new List<int>();
        slots.Add(int.Parse(Lvl1.Text));
        slots.Add(int.Parse(Lvl2.Text));
        slots.Add(int.Parse(Lvl3.Text));
        slots.Add(int.Parse(Lvl4.Text));
        slots.Add(int.Parse(Lvl5.Text));
        slots.Add(int.Parse(Lvl6.Text));
        slots.Add(int.Parse(Lvl7.Text));
        slots.Add(int.Parse(Lvl8.Text));
        slots.Add(int.Parse(Lvl9.Text));

        this.Close(slots);
    }
}