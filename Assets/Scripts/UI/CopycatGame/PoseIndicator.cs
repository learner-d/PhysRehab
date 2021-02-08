using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat;
using UnityEngine;
using UnityEngine.UI;

public class PoseIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject _indicatorModel;
    [SerializeField]
    private Color _matchNotSuccededColor;
    [SerializeField]
    private Color _matchSuccededColor;

    private Renderer[] _modelRenderers;
    private Transform preBaseJoint;
    private Transform spineBaseJoint;

    public bool IsActive { get; private set; } = false;
    //TODO: Remove
    public float CurrentTimeoutS { get; private set; } = 0;
    public float CurrentTimeS { get; private set; } = 0;

    public bool CheckPoseMatch(HumanRig poseRig)
    {
        if (IsActive)
        {
            if (PoseSelector.Instance.ActivePose.CheckRigMatch(poseRig))
            {
                OnPoseMatch();
                return true; 
            }
        }
        return false;
    }

    public void Show()
    {
        for (int i = 0; i < _modelRenderers.Length; i++)
        {
            _modelRenderers[i].forceRenderingOff = false;
        }
    }

    public void Hide()
    {
        for (int i = 0; i < _modelRenderers.Length; i++)
        {
            _modelRenderers[i].forceRenderingOff = true;
        }
    }

    private void ApplyColor(Color color)
    {
        for (int i = 0; i < _modelRenderers.Length; i++)
        {
            _modelRenderers[i].material.color = color;
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
        _modelRenderers = _indicatorModel.GetComponentsInChildren<Renderer>();
        ApplyColor(_matchNotSuccededColor);
    }

    private void Start()
    {
        PoseSelector.Instance.ActivePoseChanged += OnActivePoseChanged;
    }

    private void OnActivePoseChanged(PoseInfo prevPose, PoseInfo newPose)
    {
        if (newPose != null)
        {
            _indicatorModel.ApplyRig(newPose.PoseRig);
            CurrentTimeoutS = newPose.LifetimeS;
            CurrentTimeS = 0;
            IsActive = true;
        }
    }

    private void FixedUpdate()
    {
        if (!IsActive) return;
        
        CurrentTimeS += Time.fixedDeltaTime;
        if (CurrentTimeS > CurrentTimeoutS)
        {
            OnTimeoutExceeded();
        }
    }
}
