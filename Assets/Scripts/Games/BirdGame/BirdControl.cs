using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.BirdGame
{
    public class BirdControl : MonoBehaviour
    {

        [SerializeField]
        private KeyCode _flapKeyCode = KeyCode.Space;

        [SerializeField]
        private AudioClip flap;

        [SerializeField]
        private float velocity_Y = 1;

        [SerializeField]
        private float velocity_X = 1;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            if (Input.GetKeyDown(_flapKeyCode))
            {

                rb.velocity = Vector2.up * velocity_Y;
                AudioSource.PlayClipAtPoint(flap, Vector3.zero);
            }

            rb.transform.position += Vector3.right * velocity_X;

        }
    }

}