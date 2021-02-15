using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Collector
{
    public class Pickup : MonoBehaviour
    {
        /// <summary>
        /// Тип пікапу
        /// </summary>
        public PickupType PickupType => pickupType;
        [SerializeField]
        private PickupType pickupType;

        //Подія "Зібрано"
        public event UnityAction<Pickup> Collected;

        /// <summary>
        /// Ініціює подію "Збирання"
        /// </summary>
        private void Collect()
        {
            Collected?.Invoke(this);
        }
    }

}