using PhysRehab.Copycat;
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
        public InfoPanel InfoPanel { get; private set; }

        public GenericInGameButtons InGameButtons { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            PausePanel = GetComponentInChildren<PausePanel>();
            InfoPanel = GetComponentInChildren<InfoPanel>();
            InGameButtons = GetComponentInChildren<GenericInGameButtons>();
            _fader = GetComponent<Fader>();
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if (_visible == false)
            {
                PausePanel.Hide();
                InfoPanel.Hide();
            }

        }

        public void Btn_Start_Click()
        {
            if (UI_MAIN.Instance.ActiveGame == EGame.Collector)
                CollectorGameScene.Gameplay.StartLevel();

            else if (UI_MAIN.Instance.ActiveGame == EGame.Copycat)
            {
                if(PosePlayback.Instance.IsPlaying == false)
                    PosePlayback.Instance.StartPlayback();
                else
                    PosePlayback.Instance.Stop();
            }
        }

        public void Btn_Info_Click()
        {
            InGameButtons.Hide();
            Program.Pause();
            _fader?.Show();

            if(UI_MAIN.Instance.ActiveGame == EGame.Collector)
            {
                InfoPanel.CollectorInfo();
            }

            else if (UI_MAIN.Instance.ActiveGame == EGame.Copycat)
            {
                InfoPanel.CopyCatInfo();
            }
        }

        public void Btn_Pause_Click()
        {
            InGameButtons.Hide();
            Program.Pause();
            _fader?.Show();
            PausePanel.Show();
        }
    }
}