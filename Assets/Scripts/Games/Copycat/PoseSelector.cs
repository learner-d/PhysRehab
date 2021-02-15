using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat.UI;
using PhysRehab.UI;
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
        public event UnityAction<PoseInfo, PoseInfo> ActivePoseChanged;
        public event UnityAction<PosePack> PosePackAdded;
        public event UnityAction<PosePack> PosePackRemoved;
        public event UnityAction<PosePack, PosePack> ActivePosePackChanged;
        #endregion

        private PosePack _currentPosesPack;

        public PosePack ActivePosesPack
        {
            get => _currentPosesPack;
            private set
            {
                ActivePosePackChanged?.Invoke(_currentPosesPack, value);
                _currentPosesPack = value;
            }
        }

        public IReadOnlyList<PoseInfo> GetActivePoses()
        {
            return _currentPosesPack.Poses;
        }

        public int PosesCount => ActivePosesPack?.Poses.Count ?? 0;

        [SerializeField]
        private HumanRig _poseIndicatorDefaultRig;

        private PoseInfo _activePose;
        public PoseInfo ActivePose
        {
            get => _activePose;
            set
            {
                _activePose = value;
                ActivePoseChanged?.Invoke(_activePose, value);
            }
        }

        public void SelectPose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > ActivePosesPack.Poses.Count)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

            ActivePose = ActivePosesPack.Poses[poseIndex];
        }

        public void SelectPose(PoseInfo poseInfo)
        {
            ActivePose = poseInfo;
        }

        public void AddPose(PoseInfo poseInfo, bool makeActive)
        {
            ActivePosesPack.AddPose(poseInfo);
            if (makeActive)
                ActivePose = poseInfo;
        }

        public PoseInfo AddPose(HumanRig rig, string poseName, float duration_s)
        {
            PoseInfo poseInfo = new PoseInfo(rig, poseName, duration_s);
            ActivePosesPack.AddPose(poseInfo);
            return poseInfo;
        }

        public void RemovePose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > ActivePosesPack.Poses.Count)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");
            PoseInfo removedPose = ActivePosesPack.RemovePose(poseIndex);
        }

        public void ClearPoses()
        {
            while (ActivePosesPack?.Poses.Count > 0)
             ActivePosesPack.RemovePose(0);   
        }

        public void SavePoses()
        {
            PoseStorage.SavePosesPack(ActivePosesPack);
        }

        private void LoadPosePacks()
        {
            //TODO: rewrite
            ActivePosesPack = PoseStorage.GetPosesPack("Default");
        }

        private void Awake()
        {
            ActivePosePackChanged += (prevPosePack, newPosePack) =>
            {
                if (prevPosePack != null)
                {
                    prevPosePack.PoseAdded -= PosePack_PoseAdded;
                    prevPosePack.PoseRemoved -= PosePack_PoseRemoved;
                }
                if (newPosePack != null)
                {
                    ClearPoses();
                    foreach (PoseInfo poseInfo in newPosePack.Poses)
                        PoseAdded?.Invoke(poseInfo);

                    newPosePack.PoseAdded += PosePack_PoseAdded;
                    newPosePack.PoseRemoved += PosePack_PoseRemoved;
                }
            };
            
            Instance = this;
        }

        private void PosePack_PoseAdded(PoseInfo poseInfo)
        {
            PoseAdded?.Invoke(poseInfo);
        }

        private void PosePack_PoseRemoved(PoseInfo poseInfo)
        {
            PoseRemoved?.Invoke(poseInfo);
        }


        private void Start()
        {
            LoadPosePacks();
        }
    }

}