using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    //Номер поточного рівня
    public int LevelIndex { get; private set; }
    //Інформація про пікапи
    private PickupInfo[] pickupInfos;

    private IEnumerator SpawnPickups()
    {
        for (int i = 0; i < pickupInfos.Length; i++)
        {
            GameObject pickup_obj = PickupManager.SpawnPickup(pickupInfos[i].CellIndex);
            if (pickup_obj != null)
            {
                yield return new WaitForSeconds(pickupInfos[i].LiveTimeS);
                Destroy(pickup_obj);
            }
            else
            {
                Debug.LogError($"Couldn't spawn pickup #{i+1}/{pickupInfos.Length}!");
            }
        }
        yield break;
    }

    private void DebugLoadLevel()
    {
        pickupInfos = new PickupInfo[9];
        pickupInfos[0] = new PickupInfo(0, 1.5f);
        pickupInfos[1] = new PickupInfo(3, 1.5f);
        pickupInfos[2] = new PickupInfo(5, 1.5f);
        pickupInfos[3] = new PickupInfo(0, 1.5f);
        pickupInfos[4] = new PickupInfo(1, 1.3f);
        pickupInfos[5] = new PickupInfo(0, 1.3f);
        pickupInfos[6] = new PickupInfo(3, 1.3f);
        pickupInfos[7] = new PickupInfo(5, 1.1f);
        pickupInfos[8] = new PickupInfo(7, 1.0f);
    }

    public static void StartLevel()
    {
        //instance.StartCoroutine(instance.SpawnPickups());
        PickupGenerator.StartGeneration();
    }

    private void Awake()
    {
        instance = this;
        DebugLoadLevel();
    }
}
