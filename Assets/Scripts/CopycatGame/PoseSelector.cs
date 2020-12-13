using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private List<HumanRig> _poseRigs = new List<HumanRig>();

    [SerializeField]
    private HumanRig _poseIndicatorDefaultRig;

    public int PosesCount => _poseRigs.Count;

    public void VisualizePose(int poseIndex)
    {
        if (poseIndex < 0 || poseIndex > PosesCount)
            throw new System.IndexOutOfRangeException("'poseIndex' is out of range");

        SetPose(_poseRigs[poseIndex]);
    }

    public void SetPose(HumanRig poseRig)
    {
        _poseIndicator.SetPose(poseRig);
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
        poseActivator.onClick.AddListener(() => { SetPose(_poseRigs[poseIndex]); });
        poseActivator.GetComponentInChildren<Text>().text =  $"Поза {poseIndex+1}";
    }

    private void RemovePoseActivator(int poseIndex)
    {
        Destroy(_poseList_ScrollRect.content.Find($"Pose{poseIndex}Btn"));
    }

    private void InitializePoseIndicator()
    {
        
    }
    private void Start()
    {
        InitializePoseIndicator();
        Clear();
        Time.fixedDeltaTime = 0.3f;
    }
    private void FixedUpdate()
    {
        _poseIndicator.CheckPoseMatch(_character.CaptureRig());
    }
}
