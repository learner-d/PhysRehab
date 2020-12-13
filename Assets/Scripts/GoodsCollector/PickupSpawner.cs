using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    private float _pickupMargin = 1f;
    [SerializeField]
    private PickupSpawnZone _normalPickupSpawnZone;
    [SerializeField]
    private PickupSpawnZone _biggerScorePickupSpawnZone;
    [SerializeField]
    private GameObject _normalPickupPrefab;
    [SerializeField]
    private GameObject _bigScorePickupPrefab;
    [SerializeField]
    private LevelInfo _levelInfo/* = new MockLevelInfo()*/;
    [SerializeField]
    private int _maxPickups = 0;

    private List<Pickup> _spawnedPickups = new List<Pickup>();

    private bool _spawnIsRunning = false;

    public int SpawnedPickupsCount { get; private set; }
    public int CollectedPickupsCount { get; private set; }
    public int DestroyedPickupsCount { get; private set; }
    public int TotalPickupsCount { get; private set; }
    public bool AllPickupsSpawned => SpawnedPickupsCount >= TotalPickupsCount;
    public bool AllPickupsCollected => AllPickupsSpawned && SpawnedPickupsCount == DestroyedPickupsCount;

    //public event UnityAction SpawnStarted;
    //public event UnityAction SpawnFinished;

    private void Awake()
    {
        string levelConfigPath = Path.Combine(Application.dataPath, @"Data\PickupCollector\testLevel.cfg");
        //File.WriteAllText(levelConfigPath, JsonUtility.ToJson(_levelInfo, true));
        Initialize();
    }

    private void Initialize()
    {
        _spawnedPickups.Clear();
        TotalPickupsCount = 0;
        SpawnedPickupsCount = 0;
        CollectedPickupsCount = 0;
        DestroyedPickupsCount = 0;
        for (int i = 0; i < _levelInfo.pickupSpawnInfos.Length; i++)
        {
            TotalPickupsCount += (int)_levelInfo.pickupSpawnInfos[i].PickupsCount;
        }
        if (TotalPickupsCount > _maxPickups)
        {
            TotalPickupsCount = _maxPickups; 
        }
    }

    public void ResetState()
    {
        Initialize();
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
        //SpawnStarted?.Invoke();
        _spawnIsRunning = true;

        for (int i = 0; i < _levelInfo.SpawnInfoRecordsCount; i++)
        {
            PickupSpawnInfo spawnInfo = _levelInfo.pickupSpawnInfos[i];
            for (int j = 0; j < spawnInfo.PickupsCount; j++)
            {
                if (!_spawnIsRunning)
                    break;

                StartCoroutine(NextSpawn(spawnInfo.PickupType, spawnInfo.PickupLifeTimeS));
                
                if (SpawnedPickupsCount == _maxPickups) yield break;
                
                yield return new WaitForSeconds(spawnInfo.NextPickupSpawnDelayS);
            }
        }

        _spawnIsRunning = false;
        //SpawnFinished?.Invoke();
        yield break;
    }

    private IEnumerator NextSpawn(PickupType pickupType, float lifetimeS)
    {
        Pickup pickup = SpawnPickup(NextRandomPosition(pickupType), pickupType);
        
        yield return new WaitForSeconds(lifetimeS);

        RemovePickup(pickup);
        yield break;
    }

    private Vector3 NextRandomPosition(PickupType pickupType)
    {
        PickupSpawnZone spawnZone = pickupType == PickupType.Normal ? _normalPickupSpawnZone : _biggerScorePickupSpawnZone;
        float x = Random.Range(spawnZone.Zone.xMin, spawnZone.Zone.xMax);
        float y = Random.Range(spawnZone.Zone.yMin, spawnZone.Zone.yMax);

        return new Vector3(x, y, -1);
    }

    public Pickup SpawnPickup(Vector2 pos, PickupType pickupType = PickupType.Normal)
    {
        return SpawnPickup(new Vector3(pos.x, pos.y, -1), pickupType);
    }

    public Pickup SpawnPickup(Vector3 pos, PickupType pickupType = PickupType.Normal)
    {
        GameObject pickupPrefab = pickupType == PickupType.Normal ? _normalPickupPrefab : _bigScorePickupPrefab;
        Pickup pickup = Instantiate(pickupPrefab, pos, Quaternion.identity).GetComponent<Pickup>();
        GoodsCollectorScene.PickupObserver.Subscribe(pickup);

        _spawnedPickups.Add(pickup);
        SpawnedPickupsCount++;
        return pickup;
    }

    public void RemovePickup(Pickup pickup, bool collected = false)
    {
        int index = _spawnedPickups.FindIndex(p => p == pickup);
        if (index != -1)
        {
            Destroy(pickup.gameObject);
            _spawnedPickups.RemoveAt(index);

            if (collected)
            {
                CollectedPickupsCount++; 
            }
            DestroyedPickupsCount++;
        }
        GoodsCollectorScene.Gameplay.CheckLevelProress();
    }
}
