using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class InfoPanel : DialogPanelBase
    {
        [SerializeField]
        private Text _infoText;
        [SerializeField]
        private Image _infoImage;

        [SerializeField]
        private string _CollectorinfoText;
        [SerializeField]
        private Sprite _CollectorinfoImage;

        [SerializeField]
        private string _CopyCatinfoText;
        [SerializeField]
        private Sprite _CopyCatinfoImage;


        private GenericUI _genericUi;
        protected override void Awake()
        {
            base.Awake();
            _genericUi = GetComponentInParent<GenericUI>();
        }

        

        public void Show(string infoText, Sprite infoImage)
        {
            _infoText.text = infoText;
            _infoImage.sprite = infoImage;
        }

        public void Btn_Resume_Click()
        {
            Hide();
            _fader?.Hide();
            Time.timeScale = 1.0f;
            _genericUi.InGameButtons.Show();
        }

        public void CopyCatInfo()
        {
            Show(_CopyCatinfoText, _CopyCatinfoImage);
        }


        public void CollectorInfo()
        {
            Show(_CollectorinfoText, _CollectorinfoImage);
        }

       
    }
}