using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.BirdGame;
using PhysRehab.Core;
using PhysRehab.UI;
using PhysRehab.UI.BirdGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.UI
{
    public class BirdUI : VisibleBase
    {
        public static BirdUI Instance { get; private set; }
        public BirdLosePanel BirdLosePanel { get; private set; }
        public BirdWinPanel BirdWinPanel { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
            BirdLosePanel = GetComponentInChildren<BirdLosePanel>();
            BirdWinPanel = GetComponentInChildren<BirdWinPanel>();
        }

        public void Initialize()
        {
            Bird.Crashed += OnBirdCrashed;
            LevelEndZone.Reached += OnLevelPassed;
        }

        private void OnBirdCrashed()
        {
            BirdLosePanel.ShowLosePanel();
        }

        private void OnLevelPassed(LevelEndZone arg0, GameObject arg1)
        {
            BirdWinPanel.ShowWinPanel();
        }

        public void Shutdown()
        {
            Bird.Crashed -= OnBirdCrashed;
            LevelEndZone.Reached -= OnLevelPassed;
        }


        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if (_visible == false)
            {
                UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
                UI_MAIN.Instance.GenericUI.PausePanel.Hide();
                UI_MAIN.Instance.Dialogs.LevelCompletePanel.Hide();

                BirdLosePanel.Hide();
                BirdWinPanel.Hide();
            }
        }
    }
}
