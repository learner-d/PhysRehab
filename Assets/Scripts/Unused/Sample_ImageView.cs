using System;
using UnityEngine;
using UnityEngine.UI;
using LightBuzz.Vitruvius;
using LightBuzz;

public class Sample_ImageView : MonoBehaviour
{
    SensorAdapter adapter = null;

    public Transform imageViewTransform = null;

    private Transform[] jointPoints;
    private LineRenderer[] jointLines;
    public float updateSmoothness = 0.5f;
    public float BodyScale = 2f;

    public JointType[] JointTypes { get; private set; }
    public string[] JointNames { get; private set; }

    void Start()
    {
        JointTypes = (JointType[])Enum.GetValues(typeof(JointType));
        JointNames = Enum.GetNames(typeof(JointType));
        jointPoints = new Transform[JointNames.Length];

        for (int i = 0; i < JointTypes.Length; i++)
        {
            jointPoints[i] = GameObject.Find(JointNames[i]).transform;
            JointTypes[i] = (JointType)Enum.Parse(typeof(JointType), jointPoints[i].name);
        }

        jointLines = new LineRenderer[3];
        jointLines[0] = GameObject.Find("Spine Line").GetComponent<LineRenderer>();
        jointLines[1] = GameObject.Find("Upper Line").GetComponent<LineRenderer>();
        jointLines[2] = GameObject.Find("Lower Line").GetComponent<LineRenderer>();
    }

    void OnEnable()
    {
        adapter = new SensorAdapter(SensorType.Kinect2)
        {
            OnChangedAvailabilityEventHandler = (sender, args) =>
            {
                Debug.Log(args.SensorType + " is connected: " + args.IsConnected);
            }
        };
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
                UpdateStickman(frame, body, imageViewTransform);
            }
        }
    }

    public void UpdateStickman(Frame frame, Body body, Transform viewPlane)
    {
        bool isPlaybackFrame = frame != null && frame.IsPlaybackFrame;
        if ((!isPlaybackFrame && adapter == null) || frame == null || body == null || viewPlane == null) return;

        Vector3D viewPlanePosition = viewPlane.position;
        LightBuzz.Quaternion viewPlaneRotation = viewPlane.rotation;
        Vector3D viewPlaneScale = viewPlane.localScale;

        if (viewPlane.GetType() == typeof(RectTransform))
        {
            viewPlaneScale.Set(viewPlaneScale.X * ((RectTransform)viewPlane).root.localScale.x * ((RectTransform)viewPlane).rect.size.x,
                viewPlaneScale.Y * ((RectTransform)viewPlane).root.localScale.y * ((RectTransform)viewPlane).rect.size.y, 1);
        }

        float smoothness = Mathf.Lerp(1f, Time.deltaTime, updateSmoothness);

        //Vector3D currPosition;

        for (int i = 0; i < jointPoints.Length; i++)
        {
            //if (isPlaybackFrame)
            //{
            //    currPosition = VideoPlayer.WorldToImageSpace(JointTypes[i], frame, body).GetPositionOnPlane(
            //        frame.ImageWidth, frame.ImageHeight, viewPlanePosition, viewPlaneRotation, viewPlaneScale);
            //}
            //else
            //{
            //    currPosition = adapter.WorldToImageSpace(body.Joints[JointTypes[i]].WorldPosition).GetPositionOnPlane(
            //        frame.ImageWidth, frame.ImageHeight, viewPlanePosition, viewPlaneRotation, viewPlaneScale);
            //}

            //jointPoints[i].position = Vector3D.Lerp(jointPoints[i].position, currPosition, smoothness);

            jointPoints[i].position = body.Joints[JointTypes[i]].WorldPosition * BodyScale;
        }

        jointLines[0].SetPosition(0, jointPoints[0].position);
        jointLines[0].SetPosition(1, jointPoints[1].position);
        jointLines[0].SetPosition(2, jointPoints[2].position);
        jointLines[0].SetPosition(3, jointPoints[3].position);
        jointLines[0].SetPosition(4, jointPoints[4].position);

        jointLines[1].SetPosition(0, jointPoints[8].position);
        jointLines[1].SetPosition(1, jointPoints[7].position);
        jointLines[1].SetPosition(2, jointPoints[6].position);
        jointLines[1].SetPosition(3, jointPoints[5].position);
        jointLines[1].SetPosition(4, jointPoints[2].position);
        jointLines[1].SetPosition(5, jointPoints[9].position);
        jointLines[1].SetPosition(6, jointPoints[10].position);
        jointLines[1].SetPosition(7, jointPoints[11].position);
        jointLines[1].SetPosition(8, jointPoints[12].position);

        jointLines[2].SetPosition(0, jointPoints[16].position);
        jointLines[2].SetPosition(1, jointPoints[15].position);
        jointLines[2].SetPosition(2, jointPoints[14].position);
        jointLines[2].SetPosition(3, jointPoints[13].position);
        jointLines[2].SetPosition(4, jointPoints[4].position);
        jointLines[2].SetPosition(5, jointPoints[17].position);
        jointLines[2].SetPosition(6, jointPoints[18].position);
        jointLines[2].SetPosition(7, jointPoints[19].position);
        jointLines[2].SetPosition(8, jointPoints[20].position);
    }

}