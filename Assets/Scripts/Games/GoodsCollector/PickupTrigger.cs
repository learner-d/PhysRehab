using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.Collector
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class PickupTrigger : MonoBehaviour
    {
        private Pickup parent; // посилання на головний скрипт пікапу
        private void Awake()
        {
            parent = GetComponentInParent<Pickup>();
        }

        /// <summary>
        /// Запускається при зіткненні з іншим ігровим об'єктом
        /// </summary>
        /// <param name="collision">колізія ігрового об'єкту,
        /// з яким відбулося зіткнення</param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Перевірка типу об'єкта з яким зіткнулися
            if (collision.CompareTag("Hand"))
                parent.SendMessage("Collect"); // просимо батьківський скрипт
                                               // ініціювати подію "Збирання"
        }
    } 
}
