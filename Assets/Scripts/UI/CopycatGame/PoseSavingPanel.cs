using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat.UI
{
    public class PoseSavingPanel : MonoBehaviour
    {
        [SerializeField]
        private InputField _poseName_infld;
        [SerializeField]
        private InputField _poseDuration_infld;
        [SerializeField]
        [Range(0, 1)]
        private float _fading;

        public string PoseName { get; private set; } = "";
        public float PoseDuration { get; private set; } = float.NaN;
        public bool DataAcquired { get; private set; } = false;
        public bool Visible { get; private set; } = false;

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
            UI.Instance.Fading(_fading);
            DataAcquired = false;
            gameObject.SetActive(true);
            Visible = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Visible = false;
            UI.Instance.Fading(0);
        }
    }

}