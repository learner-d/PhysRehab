using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public struct PickupSpawnInfo
{
    public PickupType PickupType;
    public uint PickupsCount;
    public float PickupLifeTimeS;
    public float NextPickupSpawnDelayS;
}
