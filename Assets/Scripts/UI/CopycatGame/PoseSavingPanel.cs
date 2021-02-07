using System.Collections;
using System.Collections.Generic;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat.UI
{
    public class PoseSavingPanel : MonoBehaviour
    {
        public static PoseSavingPanel Instance { get; private set; }

        [SerializeField]
        private InputField _poseName_infld;
        [SerializeField]
        private InputField _poseDuration_infld;
        [SerializeField]
        [Range(0, 1)]
        private float _fading;
        [SerializeField]
        private Fader _fader;

        public string PoseName { get; private set; } = "";
        public float PoseDuration { get; private set; } = float.NaN;
        public bool DataAcquired { get; private set; } = false;
        public bool Visible { get; private set; } = false;

        private void Awake()
        {
            Instance = this;
        }

        public void SaveBtn_OnClick()
        {
            PoseName = _poseName_infld.text;
            if (float.TryParse(_poseDuration_infld.text, out float duration) && duration > 0)
            {
                PoseDuration = duration;
                DataAcquired = true;
            }
            Hide();
        }

        public void CancelBtn_OnClick()
        {
            Hide();
        }

        public void Show()
        {
            _fader.Fading(_fading);
            DataAcquired = false;
            gameObject.SetActive(true);
            Visible = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Visible = false;
            _fader.Fading(0);
        }
    }

}