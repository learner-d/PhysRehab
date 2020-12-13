using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class PoseInfo
{
    [SerializeField]
    private HumanRig _poseRig;
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _lifetimeS;

    public string Name => _name;
    public HumanRig PoseRig => _poseRig;
    public float LifetimeS => _lifetimeS;

    public PoseInfo(HumanRig humanRig, string name, float lifetimeS)
    {
        _name = name;
        _poseRig = humanRig;
        _lifetimeS = lifetimeS;
    }
}
