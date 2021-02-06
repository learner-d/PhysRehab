using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private PickupType pickupType;

    public event UnityAction<Pickup> Collected;
    public PickupType PickupType => pickupType;

    public void Collect()
    {
        Collected?.Invoke(this);
    }

}
