using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnZone : MonoBehaviour
{
    private bool initialized = false;
    private Rect zone = default;
    [SerializeField] private bool renderInGame = false;
    
    public Rect Zone
    {
        get
        {
            if (!initialized)
                Initialize();
            return zone;
        }
    }
    
    private void Initialize()
    {
        Vector2 centerPosition = transform.position;
        Vector2 scale = transform.lossyScale;
        Vector2 minCornerPosition = centerPosition - scale / 2;
        zone = new Rect(minCornerPosition, scale);
        initialized = true;
    }

    private void Awake()
    {
        GetComponent<SpriteRenderer>().forceRenderingOff = !renderInGame;
    }
}
