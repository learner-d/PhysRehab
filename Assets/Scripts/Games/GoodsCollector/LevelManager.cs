using System.Collections;
using System.Collections.Generic;
using PhysRehab.Scenes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int LevelIndex { get; private set; }

    public void StartLevel()
    {
        CollectorGameScene.PickupSpawner.StartSpawning();
    }
}
