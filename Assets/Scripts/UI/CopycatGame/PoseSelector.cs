using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat.UI
{
    public class PoseSelector : MonoBehaviour
    {
        [SerializeField]
        private PoseIndicator _poseIndicator;
        [SerializeField]
        private GameObject _character;
        [SerializeField]
        private ScrollRect _poseList_ScrollRect;
        [SerializeField]
        private Button _poseSelectBtnPrefab;
        [SerializeField]
        private Dropdown _posesPackSelector;
        [SerializeField]
        private PoseSavingPanel _poseSavingPanel;

        private PosesPack _currentPosesPack;

        //private List<HumanRig> _poseRigs = new List<HumanRig>();

        [SerializeField]
        private HumanRig _poseIndicatorDefaultRig;

        public int PosesCount => _currentPosesPack.Poses.Count;

        public void VisualizePose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > PosesCount)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

            SetPose(_currentPosesPack.Poses[poseIndex]);
        }

        public void SetPose(PoseInfo poseInfo)
        {
            _poseIndicator.SetPose(poseInfo.PoseRig);
        }

        public void CapturePoseBtn_OnClick()
        {
            _poseSavingPanel.Show();
            StartCoroutine(retrievePoseData(_character.CaptureRig()));
        }

        private IEnumerator retrievePoseData(HumanRig poseRig)
        {
            if (_poseSavingPanel.Visible)
            {
                yield return new WaitUntil(() => _poseSavingPanel.Visible == false);
                if (_poseSavingPanel.DataAcquired)
                {
                    PoseInfo poseInfo = new PoseInfo(poseRig, _poseSavingPanel.PoseName, _poseSavingPanel.PoseDuration);
                    AddPoseActivator(PosesCount, poseInfo);
                    _currentPosesPack.AddPose(poseInfo);
                }
            }
            yield break;
        }

        public void RemovePose(int poseIndex)
        {
            if (poseIndex < 0 || poseIndex > PosesCount)
                throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

            RemovePoseActivator(poseIndex);
            //_poseRigs.RemoveAt(poseIndex);
        }

        public void ClearPoses()
        {
            foreach (Transform child in _poseList_ScrollRect.content)
                if (child.name.StartsWith("Pose") && child.name.EndsWith("Btn"))
                    Destroy(child.gameObject);
            _currentPosesPack.ClearPoses();
        }

        public void SavePoses()
        {
            PoseStorage.SavePosesPack(_currentPosesPack);
        }

        private void AddPoseActivator(int poseIndex, PoseInfo pose)
        {
            Button poseActivator = Instantiate(_poseSelectBtnPrefab, _poseList_ScrollRect.content);
            poseActivator.transform.SetSiblingIndex(poseActivator.transform.parent.childCount - 2);
            poseActivator.name = $"Pose{poseIndex}Btn";
            poseActivator.onClick.AddListener(() => { SetPose(_currentPosesPack.Poses[poseIndex]); });

            var poseNameTxt = poseActivator.GetComponentInChildren<Text>();
            if (string.IsNullOrEmpty(pose.Name))
            {
                poseNameTxt.text = $"Поза {poseIndex + 1}"; 
            }
            else
            {
                if (float.IsNaN(pose.LifetimeS) || float.IsInfinity(pose.LifetimeS))
                    poseNameTxt.text = pose.Name; 
                else
                    poseNameTxt.text = $"{pose.Name} ({pose.LifetimeS: 0.0} сек.)";
            }
        }

        private void RemovePoseActivator(int poseIndex)
        {
            Destroy(_poseList_ScrollRect.content.Find($"Pose{poseIndex}Btn"));
        }

        private void InitializePosesPackSelector()
        {
            _posesPackSelector.ClearOptions();
            List<Dropdown.OptionData> optionDatas = new List<Dropdown.OptionData>();
            List<string> posesPacksNames = PoseStorage.GetPosesPacksNames();
            for (int i = 0; i < posesPacksNames.Count; i++)
            {
                optionDatas.Add(new Dropdown.OptionData(posesPacksNames[i]));
            }
            optionDatas.Add(new Dropdown.OptionData("<Додати>"));
            _posesPackSelector.AddOptions(optionDatas);
        }

        private void InitializePoseSelector()
        {
            _currentPosesPack = PoseStorage.GetPosesPack("Default");
            for (int i = 0; i < _currentPosesPack.Poses.Count; i++)
            {
                AddPoseActivator(i, _currentPosesPack.Poses[i]);
            }
        }

        private void Awake()
        {
            InitializePosesPackSelector();
            InitializePoseSelector();
        }

        private void Start()
        {
            Time.fixedDeltaTime = 0.3f;
        }
        private void FixedUpdate()
        {
            _poseIndicator.CheckPoseMatch(_character.CaptureRig());
        }
    }

}