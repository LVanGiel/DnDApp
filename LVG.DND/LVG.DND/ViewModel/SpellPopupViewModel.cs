using CommunityToolkit.Mvvm.ComponentModel;
using LVG.DND.Models;
using LVG.DND.streaming;

namespace LVG.DND.ViewModel
{
    public partial class SpellPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        public Spell spell;
        Streaming _stream = new Streaming();
        public SpellPopupViewModel(Spell _spell = null)
        {
            if (_spell == null)
            {
                _spell = new Spell();
            }
            Spell = _spell;
        }
    }
}
