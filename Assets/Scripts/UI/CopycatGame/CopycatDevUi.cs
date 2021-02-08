using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.Copycat
{
    public class CopycatDevUi : MonoBehaviour
    {
        public static CopycatDevUi Instance { get; private set; }
        [SerializeField]
        private bool _renderInGame = true;
        [SerializeField]
        private ScrollRect _poseList_ScrollRect;
        [SerializeField]
        private Dropdown _posesPackSelector;
        
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            Instance = this;
        }

        private void Start()
        {
            InitializePosesPackSelector();
            //TODO: handle it
            if(PoseSelector.Instance == null)
                return;
            PoseSelector.Instance.PoseAdded += AddPoseActivator;
            PoseSelector.Instance.PoseRemoved += RemovePoseActivator;
        }
        private void Update()
        {
            _canvas.enabled = _renderInGame;
        }

        /// <summary>
        /// TODO: Do One time initialization
        /// </summary>
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

        public void Btn_Menu_Click()
        {
            Program.GoToMainMenu();
        }

        #region Pose Selector
        private void AddPoseActivator(PoseInfo pose)
        {
            try
            {
                //TODO: remove poseIndex
                int poseIndex = PoseSelector.Instance.PosesCount;
                Button poseActivator = new GameObject($"Pose{poseIndex}Btn").AddComponent<Button>();
                poseActivator.transform.parent = _poseList_ScrollRect.content;
                poseActivator.transform.SetSiblingIndex(poseActivator.transform.parent.childCount - 2);

                try
                {
                    poseActivator.gameObject
                                .AddComponent<DataBinder<PoseInfo>>()
                                .DataSource = pose;
                }
                catch (NullReferenceException e)
                {
                    throw e;
                }

                poseActivator.onClick.AddListener(() => PoseSelector.Instance.SelectPose(pose));

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
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        private void RemovePoseActivator(PoseInfo poseInfo)
        {
            foreach (GameObject child in _poseList_ScrollRect.content)
            {
                DataBinder<PoseInfo> childDataBind = child.GetComponent<DataBinder<PoseInfo>>();
                if (childDataBind?.DataSource == poseInfo)
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
        #endregion

        public void Btn_CapturePose_Click()
        {
            PoseSelector.Instance.CapturePoseBtn_OnClick();
        }

        public void Btn_Save_Click()
        {
            PoseSelector.Instance.SavePoses();
        }
    } 
}
