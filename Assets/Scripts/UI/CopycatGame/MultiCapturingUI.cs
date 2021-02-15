using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat;
using UnityEngine;

namespace PhysRehab.UI.CopycatGame
{
    public class MultiCapturingUI : VisibleBase
    {
        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if(_visible == false)
            {

            }
        }

        public void Initialize()
        {
            Dialogs.Instance.MultiCapturePanel.DataAquiredEvent += OnCapturingDataAcquired;

            MultiPoseCapturer.Instance.CapturingStarted += OnCapturingStarted;
            MultiPoseCapturer.Instance.PoseCaptured += OnPoseCaptured;
            MultiPoseCapturer.Instance.CapturingFinished += OnCapturingFinished;
        }

        public void Shutdown()
        {
            MultiPoseCapturer.Instance.CapturingStarted -= OnCapturingStarted;
            MultiPoseCapturer.Instance.PoseCaptured -= OnPoseCaptured;
            MultiPoseCapturer.Instance.CapturingFinished -= OnCapturingFinished;

            Dialogs.Instance.MultiCapturePanel.DataAquiredEvent -= OnCapturingDataAcquired;
        }

        private void OnCapturingDataAcquired(string posePackName, int count, float interval)
        {
            MultiPoseCapturer.Instance.StartCapturing(posePackName, count, interval);
        }

        private void OnCapturingStarted()
        {
            Show();
        }

        private void OnPoseCaptured()
        {
            
        }

        private void OnCapturingFinished()
        {
            Dialogs.Instance.MessageBox.Show("Серійне захоплення", "Захоплення завершено");
            Hide();
        }

        public void Btn_Stop_Click()
        {

        }
    }
}