using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    private static PickupGenerator instance;
    private bool generationIsRunning = false;
    [SerializeField]
    private int pickupsCount = 20;
    [SerializeField]
    private float pickupLifetimeS = 2f;
    [SerializeField]
    private Transform lowerBound;
    [SerializeField]
    private Transform upperBound;
    [SerializeField]
    private float pickupMargin = 1f;
    private void Awake()
    {
        instance = this;
    }

    public static void StartGeneration()
    {
        if (instance.generationIsRunning)
            StopGeneration();
        instance.generationIsRunning = true;
        instance.StartCoroutine(instance.GenerationCoroutine());
    }

    public static void StopGeneration()
    {
        instance.generationIsRunning = false;
    }

    private IEnumerator GenerationCoroutine()
    {
        for (int i = 0; i < instance.pickupsCount && instance.generationIsRunning; i++)
        {
            StartCoroutine(SpawnTimedPickup(NextRandomPosition(), pickupLifetimeS));
            float waitTime = Random.Range(1.5f, 2f);
            yield return new WaitForSeconds(waitTime);
        }
        generationIsRunning = false;
        yield break;
    }

    private IEnumerator SpawnTimedPickup(Vector3 position, float lifetimeS)
    {
        GameObject pickup = PickupManager.SpawnPickup(position);
        yield return new WaitForSeconds(lifetimeS);
        Destroy(pickup);
        yield break;
    }

    private Vector3 NextRandomPosition()
    {
        float x = Random.Range(lowerBound.position.x, upperBound.position.x);
        float y = Random.Range(lowerBound.position.y, upperBound.position.y);

        return new Vector3(x, y, -1);
    }
}
