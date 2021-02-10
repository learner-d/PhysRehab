using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI.CollectorGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CollectorUI : VisibleBase
    {
        private CollectorPreConfingUI _preConfingUi;
        public CollectorPreConfingUI PreConfingUi => _preConfingUi;
        
        private CollectorUIHud _collectorUiHud;
        public CollectorUIHud HUD => _collectorUiHud;

        protected override void Awake()
        {
            base.Awake();
            _preConfingUi = GetComponentInChildren<CollectorPreConfingUI>();
            _collectorUiHud = GetComponentInChildren<CollectorUIHud>();
        }

        private void OnLevelLoaded()
        {
            UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
            UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
            UI_MAIN.Instance.Dialogs.LevelCompletePanel.Hide();
            _collectorUiHud.Hide();
            _preConfingUi.Show();
        }

        private void OnLevelStarted()
        {
            //TODO: rewrite
            _preConfingUi.Hide();
            UI_MAIN.Instance.Dialogs.StartLevelPanel.Show(1, 10);
        }

        private void OnGameStarted()
        {
            UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
            _collectorUiHud.Show();
        }

        private void OnLevelPassed()
        {
            _collectorUiHud.Hide();
            UI_MAIN.Instance.Dialogs.LevelCompletePanel.Show(1,
                CollectorGameScene.PickupSpawner.TotalPickupsCount,
                CollectorGameScene.PickupSpawner.CollectedPickupsCount,
                CollectorGameScene.ScoreCounter.Score);
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if(_visible == false)
            {
                UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
                UI_MAIN.Instance.GenericUI.PausePanel.Hide();
                UI_MAIN.Instance.Dialogs.LevelCompletePanel.Hide();
            }
        }

        public void WireupGameEvents()
        {
            if (CollectorGameScene.Gameplay)
            {
                CollectorGameScene.Gameplay.LevelLoaded += OnLevelLoaded;
                CollectorGameScene.Gameplay.LevelStarted += OnLevelStarted;
                CollectorGameScene.Gameplay.GameStarted += OnGameStarted;
                CollectorGameScene.Gameplay.LevelPassed += OnLevelPassed;
            }
        }

        public void UnwireupGameEvents()
        {
            if (CollectorGameScene.Gameplay)
            {
                CollectorGameScene.Gameplay.LevelLoaded -= OnLevelLoaded;
                CollectorGameScene.Gameplay.LevelStarted -= OnLevelStarted;
                CollectorGameScene.Gameplay.GameStarted -= OnGameStarted;
                CollectorGameScene.Gameplay.LevelPassed -= OnLevelPassed;
            }
        }
    }

}