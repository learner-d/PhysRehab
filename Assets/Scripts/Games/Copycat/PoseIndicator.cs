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

    private PoseSelector _poseSelector;
    private PoseComparer _poseComparer;


    private void InitializeModel()
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
        InitializeModel();
        _modelRenderers = _indicatorModel.GetComponentsInChildren<Renderer>();
        ApplyColor(_matchNotSuccededColor);
    }

    private void OnEnable()
    {
        if (_poseSelector == null)
        {
            _poseSelector = FindObjectOfType<PoseSelector>();
            Debug.Assert(_poseSelector != null);
        }
        if (_poseComparer == null)
        {
            _poseComparer = FindObjectOfType<PoseComparer>();
            Debug.Assert(_poseComparer != null);
        }

        _poseSelector.ActivePoseChanged += OnActivePoseChanged;
        _poseComparer.PoseMatch += OnPoseMatch;
    }

    private void OnDisable()
    {
        _poseSelector.ActivePoseChanged -= OnActivePoseChanged;
        _poseComparer.PoseMatch -= OnPoseMatch;
    }

    private Coroutine _matchIndicatingCoroutine;
    private IEnumerator IndicatePoseMatch()
    {
        ApplyColor(_matchSuccededColor);
        yield return new WaitForSeconds(3f);
        ApplyColor(_matchNotSuccededColor);
        _matchIndicatingCoroutine = null;
    }

    private void OnPoseMatch()
    {
        if(_matchIndicatingCoroutine == null)
            _matchIndicatingCoroutine = StartCoroutine(IndicatePoseMatch());
    }

    private void OnActivePoseChanged(PoseInfo prevPose, PoseInfo newPose)
    {
        if (newPose != null)
        {
            _indicatorModel.ApplyRig(newPose.PoseRig);
            if (_matchIndicatingCoroutine != null)
            {
                StopCoroutine(_matchIndicatingCoroutine);
                ApplyColor(_matchNotSuccededColor);
                _matchIndicatingCoroutine = null;
            }
        }
    }
    
    private void ApplyColor(Color color)
    {
        foreach (Renderer modelRenderer in _modelRenderers)
            modelRenderer.material.color = color;
    }

    public void Show()
    {
        for (int i = 0; i < _modelRenderers.Length; i++)
            _modelRenderers[i].forceRenderingOff = false;
    }
    public void Hide()
    {
        for (int i = 0; i < _modelRenderers.Length; i++)
            _modelRenderers[i].forceRenderingOff = true;
    }
}
