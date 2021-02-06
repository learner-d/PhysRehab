using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class LevelInfo : ScriptableObject
{
    public PickupSpawnInfo[] pickupSpawnInfos;
    public int SpawnInfoRecordsCount { get => pickupSpawnInfos.Length; }
}