using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField]
    private GameObject pickup;
    [SerializeField]
    private Transform[] pickupPoints = new Transform[8];
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip pickupCollectSound;

    public static GameObject SpawnPickup(int pckp_point_indx)
    {
        if (pckp_point_indx >= 0 && pckp_point_indx < instance.pickupPoints.Length)
        {
            return SpawnPickup(instance.pickupPoints[pckp_point_indx].position);
        }
        else
        {
            Debug.LogError("pickup point index is out of range!");
            return null;
        }
    }

    public static GameObject SpawnPickup(Vector3 pos)
    {
        return Instantiate(instance.pickup, pos, Quaternion.identity);
    }

    //Корутина: Створення фейкового об'єкту, для збирання монети
    private IEnumerator SpawnFakeHand(Vector3 pos)
    {
        GameObject hand = new GameObject();
        hand.tag = "Hand";
        hand.AddComponent<BoxCollider2D>();
        hand.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        hand.transform.position = pos;
        yield return new WaitForSeconds(1f);
        Destroy(hand);
        yield break;
    }

    public static void CollectPickup(GameObject pickup)
    {
        if (pickup.tag == "Pickup")
        {
            instance.audioSource.PlayOneShot(instance.pickupCollectSound);
            ScoresManager.AddScore(10);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GlobalSettings.DebugMode)
        {
            if (Input.GetMouseButtonDown(0))  //коли відбувся клік ЛКМ
            {
                //Координати миші
                Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //Створюємо фейковий об'єкт
                StartCoroutine(SpawnFakeHand(clickPos));
            }
            else if (Input.GetMouseButtonDown(1)) //коли відбувся клік ПКМ
            {
                //Координати миші
                Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                clickPos.z = 0;

                //Створюємо пікап
                SpawnPickup(clickPos);
            } 
        }
    }
}