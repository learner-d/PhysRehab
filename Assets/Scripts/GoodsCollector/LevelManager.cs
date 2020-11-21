using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int LevelIndex { get; private set; }

    public void StartLevel()
    {
        Utils.PickupSpawner.StartSpawning();
    }
}
