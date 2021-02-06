using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#pragma warning disable 649
namespace PhysRehab.Copycat
{
    public class PoseSelector : MonoBehaviour
    {
        public static PoseSelector Instance { get; private set; }

        #region Events
        public event UnityAction<PoseInfo> PoseAdded;
        public event UnityAction<PoseInfo> PoseRemoved;
        public event UnityAction<PoseInfo> ActivePoseChanged;
        public event UnityAction<PosePack> PosePackAdded;
        public event UnityAction<PosePack> PosePackRemoved;
        public event UnityAction<PosePack> ActivePosePackChanged;
        #endregion

        [SerializeField]
        private PoseIndicator _poseIndicator;
        [SerializeField]
        private GameObject _character;

        private PosePack _currentPosesPack;

        [SerializeField]
        private HumanRig _poseIndicatorDefaultRig;

        public int PosesCount => _currentPosesPack.Poses.Count;

        private PoseInfo _activePose;
        public PoseInfo ActivePose
        {
            get => _activePose;
            private set
            {
                _activePose = value;
                ActivePoseChanged?.Invoke(value);
            }
        }

        public void SelectPose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > PosesCount)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

            ActivePose = _currentPosesPack.Poses[poseIndex];
        }

        public void SelectPose(PoseInfo poseInfo)
        {
            ActivePose = poseInfo;
        }

        //TODO: rewrite immediately!
        public void CapturePoseBtn_OnClick()
        {
            PoseSavingPanel.Instance.Show();
            StartCoroutine(retrievePoseData(_character.CaptureRig()));
        }

        private IEnumerator retrievePoseData(HumanRig poseRig)
        {
            if (PoseSavingPanel.Instance.Visible)
            {
                yield return new WaitUntil(() => PoseSavingPanel.Instance.Visible == false);
                if (PoseSavingPanel.Instance.DataAcquired)
                {
                    AddPose(poseRig, PoseSavingPanel.Instance.PoseName, PoseSavingPanel.Instance.PoseDuration);
                }
            }
            yield break;
        }

        public void AddPose(PoseInfo poseInfo)
        {
            _currentPosesPack.AddPose(poseInfo);
            PoseAdded?.Invoke(poseInfo);
        }

        public PoseInfo AddPose(HumanRig rig, string poseName, float duration_s)
        {
            PoseInfo poseInfo = new PoseInfo(rig, poseName, duration_s);
            _currentPosesPack.AddPose(poseInfo);
            PoseAdded?.Invoke(poseInfo);
            return poseInfo;
        }

        public void RemovePose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > PosesCount)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");
            PoseInfo removedPose = _currentPosesPack.RemovePose(poseIndex);
            PoseRemoved?.Invoke(removedPose);
        }

        public void ClearPoses()
        {
            while (_currentPosesPack.Poses.Count > 0)
             _currentPosesPack.RemovePose(0);   
        }

        public void SavePoses()
        {
            PoseStorage.SavePosesPack(_currentPosesPack);
        }

        private void LoadPosePacks()
        {
            //TODO: rewrite
            _currentPosesPack = PoseStorage.GetPosesPack("Default");
            foreach (PoseInfo pose in _currentPosesPack.Poses)
                AddPose(pose);
        }

        private void Awake()
        {
            Instance = this;
            LoadPosePacks();
        }

        private void FixedUpdate()
        {
            _poseIndicator.CheckPoseMatch(_character.CaptureRig());
        }
    }

}