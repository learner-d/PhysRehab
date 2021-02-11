using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class MessageBoxDialog : DialogPanelBase
    {
        [SerializeField]
        private Text _captionText;
        [SerializeField]
        private Text _messageText;

        [SerializeField]
        private string _caption;
        [SerializeField]
        private string _message;

        public void Show(string caption, string message)
        {
            _caption = caption;
            _message = message;
            UpdateText();
            Show();
        }

        protected override void Update()
        {
            base.Update();
            if (Application.isPlaying == false)
                UpdateText();
        }

        private void UpdateText()
        {
            _captionText.text = _caption;
            _messageText.text = _message;
        }

        public void Btn_Ok_Click()
        {
            Hide();
        }
    }
}