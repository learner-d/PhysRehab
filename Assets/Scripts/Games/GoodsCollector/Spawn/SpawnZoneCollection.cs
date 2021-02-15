using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnZoneCollection : MonoBehaviour
{
    public static SpawnZoneCollection Instance { get; private set; }

    [SerializeField]
    private PickupSpawnZone[] _spawnZones;

    public void MarkAsActive(int zoneIndex)
    {
        Debug.Assert(zoneIndex >= 0 && zoneIndex < _spawnZones.Length);
        _spawnZones[zoneIndex].IsActive = true;
    }

    public void MarkAsInactive(int zoneIndex)
    {
        Debug.Assert(zoneIndex >= 0 && zoneIndex < _spawnZones.Length);
        _spawnZones[zoneIndex].IsActive = false;
    }

    public void MarkAsActive(PickupSpawnZone spawnZone)
    {
        Debug.Assert(_spawnZones.Contains(spawnZone));
        spawnZone.IsActive = true;
    }

    public void MarkAsInctive(PickupSpawnZone spawnZone)
    {
        Debug.Assert(_spawnZones.Contains(spawnZone));
        spawnZone.IsActive = false;
    }

    public void InvertStatus(PickupSpawnZone spawnZone)
    {
        Debug.Assert(_spawnZones.Contains(spawnZone));
        spawnZone.IsActive = !spawnZone.IsActive;
    }

    public PickupSpawnZone GetRandomZone()
    {
        ///TODO: Optimize
        int[] activeZonesInd
            = _spawnZones
            .Select((zone, index) => index)
            .Where(index => _spawnZones[index].IsActive)
            .ToArray();

        if(activeZonesInd.Length > 0)
            return _spawnZones[activeZonesInd[Random.Range(0, activeZonesInd.Length)]];
        return null;
    }

    public void Initialize()
    {
        Clear();
    }

    public void Clear()
    {
        foreach (var spawZone in _spawnZones)
            spawZone.Clear();
    }

    private SpriteRenderer[] _spawnZoneSpriteRenderers;

    private void Awake()
    {
        _spawnZoneSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Instance = this;
    }
    private void OnEnable()
    {
        foreach (var spawnZoneRenderer in _spawnZoneSpriteRenderers)
            spawnZoneRenderer.enabled = true;
    }
    private void OnDisable()
    {
        foreach (var spawnZoneRenderer in _spawnZoneSpriteRenderers)
            spawnZoneRenderer.enabled = false;
    }

    private void Update()
    {
        //Get lmb click coords
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickRay.origin, clickRay.direction);

            PickupSpawnZone spawnZone = hit.collider?.GetComponent<PickupSpawnZone>();
            if (spawnZone != null)
                InvertStatus(spawnZone);
        }
    }
}
