using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject _indicatorModel;
    [SerializeField]
    private Color _matchNotSuccededColor;
    [SerializeField]
    private Color _matchSuccededColor;

    private SkinnedMeshRenderer[] _modelPartRendereds;
    private Transform preBaseJoint;
    private Transform spineBaseJoint;

    public bool IsActive { get; private set; } = false;
    public HumanRig CurrentPoseRig { get; private set; } = null;
    public float CurrentTimeoutS { get; private set; } = 0;
    public float CurrentTimeS { get; private set; } = 0;   
    public void SetPose(HumanRig poseRig, float timeoutS = float.PositiveInfinity)
    {
        if (poseRig != null)
        {
            _indicatorModel.ApplyRig(poseRig);
            CurrentPoseRig = poseRig;
            CurrentTimeoutS = timeoutS;
            CurrentTimeS = 0;
            IsActive = true; 
        }
    }

    public bool CheckPoseMatch(HumanRig poseRig)
    {
        if (IsActive)
        {
            bool match = CurrentPoseRig.CheckRigMatch(poseRig);
            if (match)
            {
                OnPoseMatch();
                return true; 
            }
        }
        return false;
    }

    public void Show()
    {
        for (int i = 0; i < _modelPartRendereds.Length; i++)
        {
            _modelPartRendereds[i].forceRenderingOff = false;
        }
    }

    public void Hide()
    {
        for (int i = 0; i < _modelPartRendereds.Length; i++)
        {
            _modelPartRendereds[i].forceRenderingOff = true;
        }
    }

    private void ApplyColor(Color color)
    {
        for (int i = 0; i < _modelPartRendereds.Length; i++)
        {
            _modelPartRendereds[i].material.color = color;
        }
    }

    private void OnPoseMatch()
    {
        StartCoroutine(IndicatePoseMatch());
        IsActive = false;
    }

    private IEnumerator IndicatePoseMatch()
    {
        ApplyColor(_matchSuccededColor);
        yield return new WaitForSeconds(3f);
        ApplyColor(_matchNotSuccededColor);
        yield break;
    }

    private void OnTimeoutExceeded()
    {
        IsActive = false;
        CurrentTimeS = 0;
        CurrentTimeoutS = 0;
    }

    private void InitializePoseIndicator()
    {
        preBaseJoint = new GameObject("PreBase").transform;
        preBaseJoint.parent = _indicatorModel.transform;
        preBaseJoint.localPosition = Vector3.zero;
        preBaseJoint.localScale = new Vector3(1.0f / 3, 1.0f / 3, 1.0f / 3);

        spineBaseJoint = _indicatorModel.transform.Find("SpineBase");
        spineBaseJoint.parent = preBaseJoint;
    }

    private void Awake()
    {
        InitializePoseIndicator();
        _modelPartRendereds = _indicatorModel.GetComponentsInChildren<SkinnedMeshRenderer>();
        ApplyColor(_matchNotSuccededColor);
    }

    private void FixedUpdate()
    {
        if (IsActive)
        {
            CurrentTimeS += Time.fixedDeltaTime;
            if (CurrentTimeS > CurrentTimeoutS)
            {
                OnTimeoutExceeded();
            }
        }
    }
}
