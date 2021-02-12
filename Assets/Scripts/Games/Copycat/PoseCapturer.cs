using System.Collections;
using System.Collections.Generic;
using PhysRehab.UI;
using UnityEngine;

namespace PhysRehab.Copycat
{
    public class PoseCapturer : MonoBehaviour
    {
        public static PoseCapturer Instance { get; private set; }

        [SerializeField]
        private GameObject _character;

        private void Awake()
        {
            Instance = this;
        }

        public void SingleCapturePose()
        {
            UI_MAIN.Instance.Dialogs.PoseSavingPanel.Show();
            StartCoroutine(Co_RetrievePoseData(_character.CaptureRig()));
        }

        private IEnumerator Co_RetrievePoseData(HumanRig poseRig)
        {
            if (UI_MAIN.Instance.Dialogs.PoseSavingPanel.Visible)
            {
                yield return new WaitUntil(() => UI_MAIN.Instance.Dialogs.PoseSavingPanel.Visible == false);
                if (UI_MAIN.Instance.Dialogs.PoseSavingPanel.DataAcquired)
                {
                     PoseSelector.Instance.AddPose(poseRig,
                         UI_MAIN.Instance.Dialogs.PoseSavingPanel.PoseName,
                         UI_MAIN.Instance.Dialogs.PoseSavingPanel.PoseDuration);
                }
            }
            yield break;
        }
    } 
}
