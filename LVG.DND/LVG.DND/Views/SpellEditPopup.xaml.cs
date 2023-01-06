using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using LVG.DND.streaming;
using LVG.DND.ViewModel;
using System.Threading.Tasks;

namespace LVG.DND.Views;

public partial class SpellEditPopup : Popup
{
    SpellPopupViewModel _vm;
    public SpellEditPopup(SpellPopupViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
    }

    private void SpellButton_Clicked(object sender, EventArgs e)
    {
        if (_vm.Spell.Name == "" || _vm.Spell.Name == null)
        {
            return;
        }
        this.Close(_vm.Spell);
    }
}