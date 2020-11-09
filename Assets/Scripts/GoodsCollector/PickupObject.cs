using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Hand")
        {
            PickupManager.CollectPickup(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
