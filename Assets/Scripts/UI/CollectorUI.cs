using PhysRehab.UI.CollectorGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CollectorUI : VisibleBase
    {
        public static CollectorUI Instance => (CollectorUI)_instance;

        private void Start()
        {
            if (Application.isPlaying)
            {
                GoodsCollectorScene.Gameplay.LevelLoaded += OnLevelLoaded;
                GoodsCollectorScene.Gameplay.LevelStarted += OnLevelStarted;
                GoodsCollectorScene.Gameplay.GameStarted += OnGameStarted;
                GoodsCollectorScene.Gameplay.LevelPassed += OnLevelPassed; 
            }
        }

        private void OnLevelLoaded()
        {
            StartLevelPanel.Instance.Hide();
            LevelCompletePanel.Instance.Hide();
            CollectorUIHud.Instance.Hide();
            CollectorPreConfingUI.Instance.Show();
        }

        private void OnLevelStarted()
        {
            //TODO: rewrite
            CollectorPreConfingUI.Instance.Hide();
            StartLevelPanel.Instance.Show(1, 10);
        }

        private void OnGameStarted()
        {
            StartLevelPanel.Instance.Hide();
            CollectorUIHud.Instance.Show();
        }

        private void OnLevelPassed()
        {
            CollectorUIHud.Instance.Hide();
            LevelCompletePanel.Instance.Show(1,
                GoodsCollectorScene.PickupSpawner.TotalPickupsCount,
                GoodsCollectorScene.PickupSpawner.CollectedPickupsCount,
                GoodsCollectorScene.ScoreCounter.Score);
        }

        private void OnDestroy()
        {
            if (Application.isPlaying)
            {
                GoodsCollectorScene.Gameplay.LevelLoaded -= OnLevelLoaded;
                GoodsCollectorScene.Gameplay.LevelStarted -= OnLevelStarted;
                GoodsCollectorScene.Gameplay.GameStarted -= OnGameStarted;
                GoodsCollectorScene.Gameplay.LevelPassed -= OnLevelPassed; 
            }
        }
    }

}