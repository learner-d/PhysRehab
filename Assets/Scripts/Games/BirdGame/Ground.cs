using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class Ground : MonoBehaviour
    {
        private Bird _bird;

        private void Awake()
        {
            _bird = FindObjectOfType<Bird>();
        }

        private void Update()
        {
            transform.position = new Vector3(_bird.transform.position.x, transform.position.y,
                transform.position.z);
        }
    } 
}
