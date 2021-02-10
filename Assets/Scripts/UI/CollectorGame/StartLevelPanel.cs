
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class StartLevelPanel : DialogPanelBase
    {
        public static StartLevelPanel Instance { get; private set; }

        [SerializeField]
        private Text _captionText;
        [SerializeField]
        private Text _objectiveText;
        
        [SerializeField]
        private int _levelIndex = 0;
        [SerializeField]
        private int _coinsCount;

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
            UpdateText();
        }

        public void Show(int levelIndex, int coinsCount)
        {
            _levelIndex = levelIndex;
            _coinsCount = coinsCount;
            UpdateText();
            Show();
        }

        protected override void Update()
        {
            base.Update();
            if(Application.isPlaying == false)
                UpdateText();
        }

        private void UpdateText()
        {
            _captionText.text = $"Рівень {_levelIndex}";
            _objectiveText.text = $"Зберіть {_coinsCount} монет.";
        }

        public void Btn_StartGame_Click()
        {
            GoodsCollectorScene.Gameplay.StartGame();
        }
    }
}
