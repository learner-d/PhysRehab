using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Copycat
{
    public class MultiPoseCapturer : MonoBehaviour
    {
        public static MultiPoseCapturer Instance { get; private set; }

        [SerializeField]
        private GameObject _character;

        private Coroutine _capturingCoroutine;

        public bool IsCapturing => _capturingCoroutine != null;

        public event UnityAction CapturingStarted;
        public event UnityAction PoseCaptured;
        public event UnityAction CapturingFinished;

        private void Awake()
        {
            Instance = this;
        }

        public void StartCapturing(string posePackName, int count, float interval)
        {
            if (string.IsNullOrEmpty(posePackName)) throw new ArgumentNullException(nameof(posePackName));
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (float.IsNaN(interval) || float.IsInfinity(interval) || interval <= 0)
                throw new ArgumentOutOfRangeException(nameof(interval));

            if(IsCapturing) throw new InvalidOperationException();

            StartCoroutine(DoCapturing(posePackName, count, interval));
        }

        private IEnumerator DoCapturing(string posePackName, int count, float interval)
        {
            CapturingStarted?.Invoke();
            for (int i = 0; i < count; i++)
            {
                PoseInfo capturedPose = new PoseInfo(_character.CaptureRig(), $"{posePackName} ({i+1})", interval);
                PoseSelector.Instance.AddPose(capturedPose, true);
                PoseCaptured?.Invoke();
                
                if(i != count-1)
                    yield return new WaitForSeconds(interval);
            }

            _capturingCoroutine = null;
            CapturingFinished?.Invoke();
        }

        public void StopCapturing()
        {
            if (IsCapturing)
            {
                StopCoroutine(_capturingCoroutine);
                CapturingFinished?.Invoke(); 
            }
        }
    } 
}
