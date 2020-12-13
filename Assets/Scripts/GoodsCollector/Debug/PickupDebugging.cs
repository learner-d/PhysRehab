using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDebugging : MonoBehaviour
{
    private void Update()
    {
        if (GlobalSettings.DebugMode)
        {
            if (Input.GetMouseButtonDown(0))  //коли відбувся клік ЛКМ
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Collider2D hitObject = Physics2D.Raycast(ray.origin, ray.direction).collider;
                Pickup pickup = hitObject?.GetComponentInParent<Pickup>();
                pickup?.Collect();
            }
            else if (Input.GetMouseButtonDown(1)) //коли відбувся клік ПКМ
            {
                //Координати миші
                Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //Створюємо пікап
                GoodsCollectorScene.PickupSpawner.SpawnPickup(clickPos);
            }
        }
    }
}
