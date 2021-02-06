using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Core;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat
{
    public class CopycatDevUi : MonoBehaviour
    {
        [SerializeField]
        private bool _renderInGame = true;

        private Canvas _canvas;
        private ScrollRect _poseList_ScrollRect;
        private Dropdown _posesPackSelector;

        private Image _faderImg;
        public static CopycatDevUi Instance { get; private set; }
        private void Awake()
        {
            //Delete mockup image
            Destroy(GetComponent<Image>());

            _canvas = GetComponent<Canvas>();
            _poseList_ScrollRect = _canvas.transform.Find("#CapturingModeUi").GetComponent<ScrollRect>();
            InitializePosesPackSelector();

            _faderImg = new GameObject().AddComponent<Image>();
            Instance = this;
        }

        private void Start()
        {
            PoseSelector.Instance.PoseAdded += AddPoseActivator;
            PoseSelector.Instance.PoseRemoved += RemovePoseActivator;
        }
        private void Update()
        {
            _canvas.enabled = _renderInGame;
        }

        private void InitializePosesPackSelector()
        {
            _posesPackSelector = _canvas.transform.Find("#Dropdown_ExercisesList").GetComponent<Dropdown>();
            _posesPackSelector.ClearOptions();
            List<string> posesPacksNames = PoseStorage.GetPosesPacksNames();
            List<Dropdown.OptionData> optionDatas
                = posesPacksNames
                    .Select(t => new Dropdown.OptionData(t))
                    .ToList();
            optionDatas.Add(new Dropdown.OptionData("<Додати>"));
            _posesPackSelector.AddOptions(optionDatas);
        }

        public void Fading(float amount)
        {
            if (amount < 0 || amount > 1)
                throw new System.ArgumentOutOfRangeException(nameof(amount));

            _faderImg.gameObject.SetActive(amount != 0);
            Color oldColor = _faderImg.color;
            _faderImg.color = new Color(oldColor.r, oldColor.g, oldColor.b, amount);
        }

        public void Btn_Menu_Click()
        {
            Program.GoToMainMenu();
        }

        #region Pose Selector
        private void AddPoseActivator(PoseInfo pose)
        {
            //TODO: remove poseIndex
            int poseIndex = PoseSelector.Instance.PosesCount;
            Button poseActivator = new GameObject($"Pose{poseIndex}Btn").AddComponent<Button>();
            poseActivator.transform.parent = _poseList_ScrollRect.content;
            poseActivator.transform.SetSiblingIndex(poseActivator.transform.parent.childCount - 2);

            poseActivator.gameObject
                .AddComponent<DataBinder<PoseInfo>>()
                .DataSource = pose;

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
