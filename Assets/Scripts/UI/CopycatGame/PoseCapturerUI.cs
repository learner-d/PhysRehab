using PhysRehab.Copycat;
using PhysRehab.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CopycatGame
{
    [RequireComponent(typeof(GraphicRaycaster))]
    public class PoseCapturerUI : VisibleBase
    {
        [SerializeField]
        private ScrollRect _poseList_ScrollRect;
        [SerializeField]
        private Dropdown _posesPackSelector;

        [SerializeField]
        private Button _btnPrefab_poseActivator;

        private int _currentPoseIndex = 0;

        public void Initialize()
        {
            if (PoseSelector.Instance == null)
                return;

            InitializePoseSelector();
            InitializePosesPackSelector();
            PoseSelector.Instance.PoseAdded += OnPoseAdded;
            PoseSelector.Instance.PoseRemoved += OnPoseRemoved;
        }


        private void InitializePosesPackSelector()
        {
            if (_posesPackSelector == null)
                return;

            _posesPackSelector.ClearOptions();
            List<string> posesPacksNames = PoseStorage.GetPosesPacksNames();
            List<Dropdown.OptionData> optionDatas
                = posesPacksNames
                    .Select(t => new Dropdown.OptionData(t))
                    .ToList();
            optionDatas.Add(new Dropdown.OptionData("<Додати>"));
            _posesPackSelector.AddOptions(optionDatas);
        }

        private void InitializePoseSelector()
        {
            ClearPoseSelector();
        }

        private void ClearPoseSelector()
        {
            while (_poseList_ScrollRect.content.childCount > 2)
            {
                DestroyImmediate(_poseList_ScrollRect.content.GetChild(0).gameObject);
            }
        }

        public void Shutdown()
        {
            if (PoseSelector.Instance == null)
                return;
            PoseSelector.Instance.PoseAdded -= OnPoseAdded;
            PoseSelector.Instance.PoseRemoved -= OnPoseRemoved;
        }

        private void OnPoseAdded(PoseInfo pose)
        {
            try
            {
                Button poseActivator = Instantiate(_btnPrefab_poseActivator, _poseList_ScrollRect.content);
                poseActivator.transform.name = "Btn_PoseActivator";
                poseActivator.transform.SetSiblingIndex(poseActivator.transform.parent.childCount - 3);

                poseActivator.gameObject
                                .AddComponent<DataBinder>()
                                .DataSource = pose;

                poseActivator.onClick.AddListener(() => {
                    PoseSelector.Instance.SelectPose(pose);
                });

                var poseNameTxt = poseActivator.GetComponentInChildren<Text>();
                if (string.IsNullOrEmpty(pose.Name))
                {
                    poseNameTxt.text = $"Поза {++_currentPoseIndex}";
                }
                else
                {
                    if (float.IsNaN(pose.LifetimeS) || float.IsInfinity(pose.LifetimeS))
                        poseNameTxt.text = pose.Name;
                    else
                        poseNameTxt.text = $"{pose.Name} ({pose.LifetimeS: 0.0} сек.)";
                }
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        private void OnPoseRemoved(PoseInfo poseInfo)
        {
            foreach (Transform child in _poseList_ScrollRect.content)
            {
                DataBinder childDataBind = child.GetComponent<DataBinder>();
                if (childDataBind?.DataSource as PoseInfo == poseInfo)
                {
                    Destroy(childDataBind.gameObject);
                    return;
                }
            }
        }

        public void Btn_ClearPoseList_Click()
        {
            PoseSelector.Instance.ClearPoses();
        }

        public void Btn_CapturePose_Click()
        {
            PoseCapturer.Instance.SingleCapturePose();
        }

        public void Btn_MultiCapturePose_Click()
        {
            Dialogs.Instance.MultiCapturePanel.Show();
        }

        public void Btn_Save_Click()
        {
            PoseSelector.Instance.SavePoses();
        }
    }
}
