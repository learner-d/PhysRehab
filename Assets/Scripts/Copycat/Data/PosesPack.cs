using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PosesPack
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private List<PoseInfo> _poses;

    public IReadOnlyList<PoseInfo> Poses => _poses;
    public string Name { get => _name; set => _name = value; }
    public void AddPose(PoseInfo poseInfo)
    {
        _poses.Add(poseInfo);
    }
    public void AddPose(HumanRig humanRig, string name, float lifetimeS)
    {
        AddPose(new PoseInfo(humanRig, name, lifetimeS));
    }
    public void ClearPoses()
    {
        _poses.Clear();
    }
    public PosesPack(string name)
    {
        _name = name;
        _poses = new List<PoseInfo>();
    }
}