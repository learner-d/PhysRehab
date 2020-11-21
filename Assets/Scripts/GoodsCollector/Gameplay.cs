using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gameplay : MonoBehaviour
{
    public event UnityAction LevelLoaded;
    public event UnityAction LevelStarted;
    public event UnityAction LevelPassed;

    private void Start()
    {
        LevelLoaded?.Invoke();
    }

    public void StartLevel()
    {
        LevelStarted?.Invoke();
        Utils.PickupSpawner.StartSpawning();
    }

    public void CheckLevelProress()
    {
        if (Utils.PickupSpawner.AllPickupsSpawned)
        {
            LevelPassed?.Invoke();
        }
    }

    public void ResetLevel()
    {
        Utils.ScoreCounter.ResetScore();
        Utils.PickupSpawner.ResetState();
        LevelLoaded?.Invoke();
    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }
}
