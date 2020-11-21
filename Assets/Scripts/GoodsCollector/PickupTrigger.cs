using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickupTrigger : MonoBehaviour
{
    private Pickup parent;
    private void Awake()
    {
        parent = GetComponentInParent<Pickup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
            parent.Collect();
    }
}
