﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat.UI;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.Copycat
{
    public class CopycatDevUi : VisibleBase
    {
        [SerializeField]
        private ScrollRect _poseList_ScrollRect;
        [SerializeField]
        private Dropdown _posesPackSelector;

        [SerializeField]
        private Button _btnPrefab_poseActivator;


        protected override void Awake()
        {
            InitializePoseSelector();
            base.Awake();
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

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if (_visible == false)
            {
                UI_MAIN.Instance.Dialogs.PoseSavingPanel.Hide();
                UI_MAIN.Instance.GenericUI.PausePanel.Hide();
            }
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
                Button poseActivator = Instantiate(_btnPrefab_poseActivator, _poseList_ScrollRect.content);
                poseActivator.transform.name = $"Pose{poseIndex}Btn";
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
            foreach (Transform child in _poseList_ScrollRect.content)
            {
                DataBinder childDataBind = child.GetComponent<DataBinder>();
                if ((childDataBind?.DataSource as PoseInfo) == poseInfo)
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
