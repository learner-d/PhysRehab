using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PosePack
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private List<PoseInfo> _poses;

    public event Action<PoseInfo> PoseAdded;
    public event Action<PoseInfo> PoseRemoved;

    public IReadOnlyList<PoseInfo> Poses => _poses;
    public string Name { get => _name; set => _name = value; }
    public void AddPose(PoseInfo poseInfo)
    {
        _poses.Add(poseInfo);
        PoseAdded?.Invoke(poseInfo);
    }
    public PoseInfo AddPose(HumanRig humanRig, string name, float lifetimeS)
    {
        PoseInfo poseInfo = new PoseInfo(humanRig, name, lifetimeS);
        AddPose(poseInfo);
        return poseInfo;
    }

    public PoseInfo RemovePose(int poseIndex)
    {
        Debug.Assert(poseIndex>=0 && poseIndex < _poses.Count);
        PoseInfo result = _poses[poseIndex];
        _poses.RemoveAt(poseIndex);
        PoseRemoved?.Invoke(result);
        return result;
    }
    public void RemovePose(PoseInfo poseInfo)
    {
        bool removeResult = _poses.Remove(poseInfo);
        Debug.Assert(removeResult);
    }
    public void ClearPoses()
    {
        _poses.Clear();
    }
    public PosePack(string name)
    {
        _name = name;
        _poses = new List<PoseInfo>();
    }
}