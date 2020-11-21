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

    private bool _spawnIsRunning = false;

    public int SpawnedPickupsCount { get; private set; }
    public int TotalPickupsCount { get; private set; }
    public bool AllPickupsSpawned => SpawnedPickupsCount == TotalPickupsCount;

    public event UnityAction SpawnStarted;
    public event UnityAction SpawnFinished;

    private void Awake()
    {
        string levelConfigPath = Path.Combine(Application.dataPath, @"Data\PickupCollector\testLevel.cfg");
        //File.WriteAllText(levelConfigPath, JsonUtility.ToJson(_levelInfo, true));
        Initialize();
    }

    private void Initialize()
    {
        SpawnedPickupsCount = 0;
        TotalPickupsCount = 0;
        for (int i = 0; i < _levelInfo.pickupSpawnInfos.Length; i++)
        {
            TotalPickupsCount += (int)_levelInfo.pickupSpawnInfos[i].PickupsCount;
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
        SpawnStarted?.Invoke();
        _spawnIsRunning = true;

        for (int i = 0; i < _levelInfo.SpawnInfoRecordsCount; i++)
        {
            PickupSpawnInfo spawnInfo = _levelInfo.pickupSpawnInfos[i];
            for (int j = 0; j < spawnInfo.PickupsCount; j++)
            {
                if (!_spawnIsRunning)
                    break;

                StartCoroutine(NextSpawn(spawnInfo.PickupType, spawnInfo.PickupLifeTimeS));
                SpawnedPickupsCount++;
                yield return new WaitForSeconds(spawnInfo.NextPickupSpawnDelayS);
            }
        }

        _spawnIsRunning = false;
        SpawnFinished?.Invoke();
        yield break;
    }

    private IEnumerator NextSpawn(PickupType pickupType, float lifetimeS)
    {
        GameObject pickup = SpawnPickup(NextRandomPosition(pickupType), pickupType);
        yield return new WaitForSeconds(lifetimeS);
        Destroy(pickup);
        yield break;
    }

    private Vector3 NextRandomPosition(PickupType pickupType)
    {
        PickupSpawnZone spawnZone = pickupType == PickupType.Normal ? _normalPickupSpawnZone : _biggerScorePickupSpawnZone;
        float x = Random.Range(spawnZone.Zone.xMin, spawnZone.Zone.xMax);
        float y = Random.Range(spawnZone.Zone.yMin, spawnZone.Zone.yMax);

        return new Vector3(x, y, -1);
    }

    public GameObject SpawnPickup(Vector2 pos, PickupType pickupType = PickupType.Normal)
    {
        return SpawnPickup(new Vector3(pos.x, pos.y, -1), pickupType);
    }

    public GameObject SpawnPickup(Vector3 pos, PickupType pickupType = PickupType.Normal)
    {
        GameObject pickupPrefab = pickupType == PickupType.Normal ? _normalPickupPrefab : _bigScorePickupPrefab;
        GameObject pickup = Instantiate(pickupPrefab, pos, Quaternion.identity);
        Utils.PickupObserver.Subscribe(pickup.GetComponent<Pickup>());
        return pickup;
    }
}
