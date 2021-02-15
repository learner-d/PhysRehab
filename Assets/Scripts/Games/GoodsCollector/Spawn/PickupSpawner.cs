using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Collector
{
    public class PickupSpawner : MonoBehaviour
    {
        public event UnityAction<Pickup> PickupSpawned;
        public event UnityAction<Pickup> PickupDestroyed;
        public event UnityAction SpawningStarted;
        public event UnityAction SpawningFinished;

        private const int _zCoord = -1;
        [SerializeField]
        private float _pickupMargin = 1f;

        [SerializeField]
        private GameObject _normalPickupPrefab;
        [SerializeField]
        private GameObject _bigScorePickupPrefab;
        [SerializeField]
        private LevelInfo _levelInfo;
        [SerializeField]
        private int _maxPickups = 0;


        private SpawnZoneCollection _spawnZonesCollection;
        private PickupObserver _pickupObserver;

        private List<Pickup> _spawnedPickups = new List<Pickup>();

        private bool _spawnIsRunning = false;

        public int TotalPickupsCount { get; private set; }
        
        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            if(_spawnZonesCollection == null)
            {
                _spawnZonesCollection = FindObjectOfType<SpawnZoneCollection>();
                Debug.Assert(_spawnZonesCollection != null);
            }
            if(_pickupObserver == null)
            {
                _pickupObserver = FindObjectOfType<PickupObserver>();
                Debug.Assert(_pickupObserver != null);
            }
            _pickupObserver.PickupCollected += OnPickupCollected;
        }


        private void OnDisable()
        {
            _pickupObserver.PickupCollected -= OnPickupCollected;
        }

        private void Initialize()
        {
            Clear();

            _spawnZonesCollection.Initialize();

            for (int i = 0; i < _levelInfo.pickupSpawnInfos.Length; i++)
                TotalPickupsCount += (int)_levelInfo.pickupSpawnInfos[i].PickupsCount;

            if (_maxPickups <= 0)
                _maxPickups = int.MaxValue;

            if (TotalPickupsCount > _maxPickups)
                TotalPickupsCount = _maxPickups;

        }

        public void Clear()
        {
            TotalPickupsCount = 0;
            _spawnedPickups.Clear();

            ///Clear spawn zones
            _spawnZonesCollection.Clear();
        }

        public void StartSpawning()
        {
            if (_spawnIsRunning)
                StopSpawning();

            StartCoroutine(SpawningCoroutine());
        }

        public void StopSpawning()
        {
            _spawnIsRunning = false;
        }

        private IEnumerator SpawningCoroutine()
        {
            _spawnIsRunning = true;
            SpawningStarted?.Invoke();
            for (int i = 0; i < _levelInfo.SpawnInfoRecordsCount; i++)
            {
                PickupSpawnInfo spawnInfo = _levelInfo.pickupSpawnInfos[i];
                for (int j = 0; j < spawnInfo.PickupsCount; j++)
                {
                    if (!_spawnIsRunning)
                        break;

                    StartCoroutine(NextSpawn(spawnInfo.PickupType, spawnInfo.PickupLifeTimeS));

                    if (_pickupObserver.SpawnedPickupsCount == _maxPickups) yield break;

                    yield return new WaitForSeconds(spawnInfo.NextPickupSpawnDelayS);
                }
            }

            _spawnIsRunning = false;
            SpawningFinished?.Invoke();
        }

        private IEnumerator NextSpawn(PickupType pickupType, float lifetimeS)
        {
            Pickup pickup = SpawnPickup(NextSpawnPosition(), pickupType);

            yield return new WaitForSeconds(lifetimeS);

            RemovePickup(pickup);
            yield break;
        }

        private Vector3 NextSpawnPosition()
        {
            ///get random spawn zone
            PickupSpawnZone spawnZone = _spawnZonesCollection.GetRandomZone();
            return spawnZone.NextCoord(_pickupMargin);
        }

        public Pickup SpawnPickup(Vector2 pos, PickupType pickupType = PickupType.Normal)
        {
            return SpawnPickup(new Vector3(pos.x, pos.y, _zCoord), pickupType);
        }

        public Pickup SpawnPickup(Vector3 pos, PickupType pickupType = PickupType.Normal)
        {
            GameObject pickupPrefab = pickupType == PickupType.Normal ? _normalPickupPrefab : _bigScorePickupPrefab;
            Pickup pickup = Instantiate(pickupPrefab, pos, Quaternion.identity).GetComponent<Pickup>();
            
            _spawnedPickups.Add(pickup);
            PickupSpawned?.Invoke(pickup);
            return pickup;
        }

        public void RemovePickup(Pickup pickup)
        {
            int index = _spawnedPickups.FindIndex(p => p == pickup);
            if (index != -1)
            {
                Destroy(pickup.gameObject);
                _spawnedPickups.RemoveAt(index);

                PickupDestroyed?.Invoke(pickup);
            }
        }

        private void OnPickupCollected(Pickup pickup)
        {
            RemovePickup(pickup);
        }
    }
}