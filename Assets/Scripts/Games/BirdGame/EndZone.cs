using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.BirdGame
{

    public class EndZone : MonoBehaviour
    {
        public static event UnityAction<EndZone, GameObject> LevelPassed;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Bird")
            {
                LevelPassed?.Invoke(this, collision.gameObject);

            }
        }
    }

}