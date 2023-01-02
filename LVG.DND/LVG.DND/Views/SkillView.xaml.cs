using LVG.DND.AppConstants;
using LVG.DND.Models;

namespace LVG.DND.Views;

public partial class SkillView : ContentView
{
    SkillNameConstants skillConst = new SkillNameConstants();
	Skill _vm = new Skill();
	public SkillView(Skill vm)
	{
		_vm = vm;
		BindingContext = vm;
		InitializeComponent();
		AddAbilityScoreLevel();

    }
	private void AddAbilityScoreLevel()
	{
		if (_vm.Level != 0 && (_vm.Level -10)/2 == _vm.Bonus)
		{
			var entry = new Entry();
			entry.Text = _vm.Level.ToString();
			SkillViewStack.Add(entry);
		}
	}
}