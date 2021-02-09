using UnityEngine;

namespace PhysRehab.UI
{
    public abstract class DialogPanelBase : VisibleBase
    {
        protected Fader _fader;

        protected override void Awake()
        {
            _fader = GetComponentInParent<Fader>();
            base.Awake();
        }

        protected override void UpdateVisibility()
        {
            if (_fader != null)
                _fader.Visible = _visible;
            base.UpdateVisibility();
        }
    }
}
