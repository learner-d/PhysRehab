using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Copycat
{
    public class PoseComparer : MonoBehaviour
    {
        public static PoseComparer  Instance { get; private set; }
        public event UnityAction PoseMatch;

        [SerializeField]
        private GameObject _character;

        public bool IsActive { get; private set; } = false;

        public float CurrentTimeoutS { get; private set; } = 0;
        public float CurrentTimeS { get; private set; } = 0;

        private PoseSelector _poseSelector;


        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            if (_poseSelector == null)
            {
                _poseSelector = FindObjectOfType<PoseSelector>();
                Debug.Assert(_poseSelector != null);
            }

            _poseSelector.ActivePoseChanged += OnActivePoseChanged;
            PoseMatch += OnPoseMatch;
        }

        private void OnDisable()
        {
            _poseSelector.ActivePoseChanged -= OnActivePoseChanged;
            PoseMatch -= OnPoseMatch;
        }

        private void OnActivePoseChanged(PoseInfo prevPose, PoseInfo newPose)
        {
            if (newPose != null)
            {
                CurrentTimeoutS = newPose.LifetimeS;
                CurrentTimeS = 0;
                IsActive = true;
            }
        }

        private void OnPoseMatch()
        {
            IsActive = false;
        }

        private void OnTimeoutExceeded()
        {
            IsActive = false;
            CurrentTimeS = 0;
            CurrentTimeoutS = 0;
        }

        private void FixedUpdate()
        {
            if (!IsActive) return;
            if (_poseSelector.ActivePose
                .CheckRigMatch(_character.CaptureRig(), 0.2f, 10f))
                PoseMatch?.Invoke();
            
            if ((CurrentTimeS += Time.fixedDeltaTime) > CurrentTimeoutS)
                OnTimeoutExceeded();
        }
    }

}