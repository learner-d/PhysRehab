﻿using System.Collections;
using System.Collections.Generic;
using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Collector
{
    public class Gameplay : MonoBehaviour
    {
        public event UnityAction LevelLoaded;
        public event UnityAction LevelStarted;
        public event UnityAction GameStarted;
        public event UnityAction LevelPassed;

        private void Start()
        {
            LevelLoaded?.Invoke();
            SpawnZoneCollection.Instance.enabled = true;
            CollectorGameScene.PickupObserver.PickupCollected += OnPickupCollected;
        }

        public void StartLevel()
        {
            LevelStarted?.Invoke();
            SpawnZoneCollection.Instance.enabled = false;
        }

        public void StartGame()
        {
            GameStarted?.Invoke();
            CollectorGameScene.PickupSpawner.StartSpawning();
        }

        private void OnPickupCollected(Pickup pickup)
        {
            if (CollectorGameScene.PickupObserver.AllPickupsCollected)
            {
                LevelPassed?.Invoke();
            }
        }

        public void ResetLevel()
        {
            CollectorGameScene.ScoreCounter.ResetScore();
            CollectorGameScene.PickupObserver.Clear();
            CollectorGameScene.PickupSpawner.Clear();
            LevelLoaded?.Invoke();
        }

        public void Pause()
        {

        }

        public void Resume()
        {

        }
    }

}