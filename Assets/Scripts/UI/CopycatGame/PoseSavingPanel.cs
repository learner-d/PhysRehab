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

        private Canvas _canvas;
        private Fader _fader;

        public string PoseName { get; private set; } = "";
        public float PoseDuration { get; private set; } = float.NaN;
        public bool DataAcquired { get; private set; } = false;
        public bool Visible { get; private set; } = false;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _fader = GetComponentInParent<Fader>();
            Instance = this;
        }

        private void Start()
        {
            Hide();
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
            DataAcquired = false;
            _canvas.enabled = true;
            _fader.IsVisible = true;
            Visible = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
            _fader.IsVisible = false;
            Visible = false;
        }
    }

}