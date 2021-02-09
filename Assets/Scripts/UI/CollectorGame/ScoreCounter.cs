using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    [RequireComponent(typeof(Text))]
    [ExecuteInEditMode]
    public class ScoreCounter : MonoBehaviour
    {
        private Text _counterText;

        [SerializeField]
        private int _score;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                UpdateText();
            }
        }
        private void Awake()
        {
            _counterText = GetComponent<Text>();
            UpdateText();
        }

        private void Update()
        {
            if(Application.isPlaying == false)
                UpdateText();
        }

        private void UpdateText()
        {
            _counterText.text = $"Рахунок: {_score}";
        }
    }
}