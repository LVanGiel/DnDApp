using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.Models;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class SpeedPopup : Popup
{
	public SpeedPopup(Character character)
	{
		InitializeComponent();
		BaseSpeedBtn.ButtonStat = character.BaseSpeed.ToString();
        BaseSpeedBtn.ButtonImageUrl = "speed.png";
        FlyingSpeedBtn.ButtonStat = character.FlyingSpeed.ToString();
        FlyingSpeedBtn.ButtonImageUrl = "flying.png";
        FloatingSpeedBtn.ButtonStat = character.FloatingSpeed.ToString();
        FloatingSpeedBtn.ButtonImageUrl = "floatspeed.png";
        SwimmingSpeedBtn.ButtonStat = character.SwimmingSpeed.ToString();
        SwimmingSpeedBtn.ButtonImageUrl = "swimspeed.png";
    }
}