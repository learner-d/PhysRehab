using LightBuzz.Vitruvius;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAnimator : MonoBehaviour
{

    //Kinect-контролер
    private SensorAdapter adapter = null;
    [SerializeField]
    private Model characterModel = null;

    private void OnEnable()
    {
        adapter = new SensorAdapter(SensorType.Kinect2)
        {
            OnChangedAvailabilityEventHandler = (sender, args) =>
            {
                Debug.Log(args.SensorType + " is connected: " + args.IsConnected);
            }
        };

        characterModel.Initialize();
    }

    void OnDisable()
    {
        if (adapter != null)
        {
            adapter.Close();
            adapter = null;
        }
    }

    void Update()
    {
        if (adapter == null) return;

        Frame frame = adapter.UpdateFrame();

        if (frame != null)
        {
            Body body = frame.GetClosestBody();

            if (body != null)
            {
                characterModel.DoAvateering(body);
                //CorrectZCoordinate();
            }
        }
    }

    void CorrectZCoordinate()
    {
        Vector3 modelPos = characterModel.AvatarRoot.transform.position;
        modelPos.z = 0;
        characterModel.AvatarRoot.transform.position = modelPos;
    }
}
