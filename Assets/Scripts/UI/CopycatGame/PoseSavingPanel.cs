using System.Collections;
using System.Collections.Generic;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat.UI
{
    public class PoseSavingPanel : DialogPanelBase
    {
        [SerializeField]
        private InputField _poseName_infld;
        [SerializeField]
        private InputField _poseDuration_infld;

        public string PoseName { get; private set; } = "";
        public float PoseDuration { get; private set; } = float.NaN;
        public bool DataAcquired { get; private set; } = false;

        protected override void Awake()
        {
            base.Awake();
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

        public override void Show()
        {
            DataAcquired = false;
            base.Show();
        }
    }
}