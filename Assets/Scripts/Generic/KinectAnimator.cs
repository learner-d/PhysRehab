using LightBuzz.Vitruvius;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KinectAnimator : MonoBehaviour
{
    [SerializeField]
    private Model _characterModel;

    private CharacterScriptedModel _characterScriptedModel;
    private SensorAdapter _adapter; //Kinect-сенсор
    private HumanRig _defaultRig;

    private void Awake()
    {
        _characterScriptedModel = _characterModel.AvatarRoot.GetComponent<CharacterScriptedModel>();
        _characterScriptedModel.OnDestroying += ResetCharacterRig;
    }

    private void Start()
    {
        if (_characterModel.AvatarRoot != null)
        {
            _defaultRig = new HumanRig(_characterModel.AvatarRoot);
        }
    }

    private void OnDestroy()
    {
        if (_characterScriptedModel!=null)
        {
            _characterScriptedModel.OnDestroying -= ResetCharacterRig; 
        }
    }

    public void ResetCharacterRig()
    {
        _characterScriptedModel?.ApplyRig(_defaultRig);
    }

    private void OnEnable()
    {
        _adapter = new SensorAdapter(SensorType.Kinect2);
        _characterModel?.Initialize();
    }

    void OnDisable()
    {
        if (_adapter != null)
        {
            _adapter.Close();
            _adapter = null;
        }
    }

    void Update()
    {
        if (_adapter == null) return;

        Frame frame = _adapter.UpdateFrame();

        if (frame != null)
        {
            Body body = frame.GetClosestBody();

            if (body != null)
            {
                _characterModel.DoAvateering(body);
            }
        }
    }
}
