using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI.CollectorGame;
using UnityEngine;

namespace PhysRehab.UI
{
    public class GenericUI : VisibleBase
    {
        private Fader _fader;
        public PausePanel PausePanel { get; private set; }
        public GenericInGameButtons InGameButtons { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            PausePanel = GetComponentInChildren<PausePanel>();
            InGameButtons = GetComponentInChildren<GenericInGameButtons>();
            _fader = GetComponent<Fader>();
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if(_visible == false)
                PausePanel.Hide();
        }

        public void Btn_Start_Click()
        {
            if (UI_MAIN.Instance.ActiveGame == EGame.Collector)
            {
                CollectorGameScene.Gameplay.StartLevel();
            }
        }

        public void Btn_Info_Click()
        {

        }

        public void Btn_Pause_Click()
        {
            InGameButtons.Hide();
            Time.timeScale = 0;
            _fader?.Show();
            PausePanel.Show();
        }
    }
}