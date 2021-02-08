using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gameplay : MonoBehaviour
{
    public event UnityAction LevelLoaded;
    public event UnityAction LevelStarted;
    public event UnityAction GameStarted;
    public event UnityAction LevelPassed;

    private void Start()
    {
        LevelLoaded?.Invoke();
    }

    public void StartLevel()
    {
        LevelStarted?.Invoke();
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
        GoodsCollectorScene.PickupSpawner.StartSpawning();
    }

    public void CheckLevelProress()
    {
        if (GoodsCollectorScene.PickupSpawner.AllPickupsCollected)
        {
            LevelPassed?.Invoke();
        }
    }

    public void ResetLevel()
    {
        GoodsCollectorScene.ScoreCounter.ResetScore();
        GoodsCollectorScene.PickupSpawner.Clear();
        LevelLoaded?.Invoke();
    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void GoToMainMenu()
    {
        Program.GoToMainMenu();
    }
}
