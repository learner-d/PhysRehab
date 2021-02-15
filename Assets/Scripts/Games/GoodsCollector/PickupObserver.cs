using System.Collections;
using System.Collections.Generic;
using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Collector
{
    public class PickupObserver : MonoBehaviour
    {
        public event UnityAction<Pickup> PickupSpawned;
        public event UnityAction<Pickup> PickupCollected;

        private PickupSpawner _pickupSpawner;

        [SerializeField]
        private int _normalScore = 10;
        [SerializeField]
        private int _biggerScore = 25;

        public int SpawnedPickupsCount { get; private set; }
        public int CollectedPickupsCount { get; private set; }
        public int DestroyedPickupsCount { get; private set; }
        public int TotalPickupsCount => _pickupSpawner.TotalPickupsCount;

        public bool SpawningIsFinished => SpawnedPickupsCount >= TotalPickupsCount;
        public bool AllPickupsCollected => SpawningIsFinished && SpawnedPickupsCount == DestroyedPickupsCount;


        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            Clear();
        }

        public void Clear()
        {
            SpawnedPickupsCount = 0;
            CollectedPickupsCount = 0;
            DestroyedPickupsCount = 0;
        }

        private void OnEnable()
        {
            if(_pickupSpawner == null)
            {
                _pickupSpawner = FindObjectOfType<PickupSpawner>();
                Debug.Assert(_pickupSpawner != null);
            }
            _pickupSpawner.PickupSpawned += OnPickupSpawned;
            _pickupSpawner.PickupDestroyed += OnPickupDestroyed;
        }


        private void OnDisable()
        {
            _pickupSpawner.PickupSpawned -= OnPickupSpawned;
            _pickupSpawner.PickupDestroyed -= OnPickupDestroyed;
        }

        public void OnPickupSpawned(Pickup pickup)
        {
            pickup.Collected += OnPickupCollected;
            SpawnedPickupsCount++;
            PickupSpawned?.Invoke(pickup);
        }
        private void OnPickupDestroyed(Pickup pickup)
        {
            pickup.Collected -= OnPickupCollected;
            DestroyedPickupsCount++;
        }

        private void OnPickupCollected(Pickup pickup)
        {
            int score = pickup.PickupType == PickupType.Normal? _normalScore : _biggerScore;
            
            CollectorGameScene.ScoreCounter.AddScore(score);
            CollectedPickupsCount++;
            PickupCollected?.Invoke(pickup);
        }
    } 
}