using UnityEngine;

namespace PhysRehab.UI.CollectorGame
{
    public class InfoPanel : DialogPanelBase
    {
        private GenericUI _genericUi;
        protected override void Awake()
        {
            base.Awake();
            _genericUi = GetComponentInParent<GenericUI>();
        }

        public void Btn_Resume_Click()
        {
            Hide();
            _fader?.Hide();
            Time.timeScale = 1.0f;
            _genericUi.InGameButtons.Show();
        }
     
    }
}