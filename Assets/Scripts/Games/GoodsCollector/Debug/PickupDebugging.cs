using System.Collections;
using System.Collections.Generic;
using PhysRehab.Scenes;
using UnityEngine;

namespace PhysRehab.Collector
{
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
                    pickup?.SendMessage("Collect");
                }
                else if (Input.GetMouseButtonDown(1)) //коли відбувся клік ПКМ
                {
                    //Координати миші
                    Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    //Створюємо пікап
                    CollectorGameScene.PickupSpawner.SpawnPickup(clickPos);
                }
            }
        }
    }

}