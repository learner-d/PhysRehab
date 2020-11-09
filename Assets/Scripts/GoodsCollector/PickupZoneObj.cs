using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZoneObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
        //gameObject.SetActive(false);
    }
}
