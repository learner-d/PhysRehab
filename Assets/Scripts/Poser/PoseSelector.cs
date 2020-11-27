using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject _poseIndicator;
    [SerializeField]
    private GameObject _character;
    [SerializeField]
    private ScrollRect _poseList_ScrollRect;
    [SerializeField]
    private Button _poseSelectBtnPrefab;

    private List<HumanRig> _poseRigs = new List<HumanRig>();
    private TransformData _poseIndicatorDefaultTransform;

    private Transform preBaseJoint;
    private Transform spineBaseJoint;

    [SerializeField]
    private HumanRig _poseIndicatorDefaultRig;
    [SerializeField]
    private HumanRig _characterDefaultRig;

    public int PosesCount => _poseRigs.Count;

    public void VisualizePose(int poseIndex)
    {
        if (poseIndex < 0 || poseIndex > PosesCount)
            throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

        VisualizePose(_poseRigs[poseIndex]);
    }

    public void VisualizePose(HumanRig poseRig)
    {
        _poseIndicator.ApplyRig(poseRig);
        //preBaseJoint.localPosition = Vector3.zero;
    }

    public void CaptureCurrentPose()
    {
        AddPoseActivator(PosesCount);
        _poseRigs.Add(_character.CaptureRig());
    }

    public void RemovePose(int poseIndex)
    {
        if (poseIndex < 0 || poseIndex > PosesCount)
            throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

        RemovePoseActivator(poseIndex);
        _poseRigs.RemoveAt(poseIndex);
    }

    public void Clear()
    {
        foreach (Button btn in _poseList_ScrollRect.content.GetComponentsInChildren<Button>())
            Destroy(btn.gameObject);
        _poseRigs.Clear();
    }

    private void AddPoseActivator(int poseIndex)
    {
        Button poseActivator = Instantiate(_poseSelectBtnPrefab, _poseList_ScrollRect.content);
        poseActivator.name = $"Pose{poseIndex}Btn";
        poseActivator.onClick.AddListener(() => { VisualizePose(_poseRigs[poseIndex]); });
        poseActivator.GetComponentInChildren<Text>().text =  $"Поза {poseIndex+1}";
    }

    private void RemovePoseActivator(int poseIndex)
    {
        Destroy(_poseList_ScrollRect.content.Find($"Pose{poseIndex}Btn"));
    }

    private void InitializePoseIndicator()
    {
        preBaseJoint = new GameObject("PreBase").transform;
        preBaseJoint.parent = _poseIndicator.transform;
        preBaseJoint.localPosition = Vector3.zero;
        preBaseJoint.localScale = new Vector3(1.0f / 3, 1.0f / 3, 1.0f / 3);
        
        spineBaseJoint = _poseIndicator.transform.Find("SpineBase");
        spineBaseJoint.parent = preBaseJoint;

        _characterDefaultRig = _character.CaptureRig();
        _poseIndicatorDefaultRig = _poseIndicator.CaptureRig();
        _poseIndicatorDefaultTransform = new TransformData(_poseIndicator.transform);
    }
    private void Start()
    {
        InitializePoseIndicator();
        Clear();
    }
}
