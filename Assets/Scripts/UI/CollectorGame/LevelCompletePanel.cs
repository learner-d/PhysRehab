using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class LevelCompletePanel : DialogPanelBase
    {
        public static LevelCompletePanel Instance { get; private set; }
        
        [SerializeField]
        private Text _captionText;
        [SerializeField]
        private Text _infoText;

        [SerializeField]
        private int _levelIndex;
        [SerializeField]
        private int _score;
        [SerializeField]
        private int _collectedCount;
        [SerializeField]
        private int _pickupCount;

        protected override void Awake()
        {
            base.Awake();
            UpdateText();
            Instance = this;
        }

        protected override void Update()
        {
            base.Update();
            if(Application.isPlaying == false)
                UpdateText();
        }

        public void Show(int levelIndex, int pickupCount, int collectedCount, int score)
        {
            _levelIndex = levelIndex;
            _pickupCount = pickupCount;
            _collectedCount = collectedCount;
            _score = score;
            UpdateText();
            Show();
        }

        private void UpdateText()
        {
            _captionText.text = $"Рівень {_levelIndex} пройдено!";
            _infoText.text = $"Рахунок: {_score}\nЗібрано {_collectedCount}/{_pickupCount}";
        }
    }
}