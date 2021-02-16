using UnityEngine;

namespace PhysRehab.UI.CollectorGame
{
    public class PausePanel : DialogPanelBase
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
            Program.Resume();
             _genericUi.InGameButtons.Show();
        }
        public void Btn_Options_Click()
        {

        }
        public void Btn_Menu_Click()
        {
            Program.GoToMainMenu();
            _genericUi.InGameButtons.Show();
            Program.Resume();
        }
    }
}