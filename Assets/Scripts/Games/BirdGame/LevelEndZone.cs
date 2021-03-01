using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.BirdGame
{

    public class LevelEndZone : MonoBehaviour
    {
        public static event UnityAction<LevelEndZone, GameObject> Reached;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Bird")
            {
                Reached?.Invoke(this, collision.gameObject);

            }
        }
    }

}