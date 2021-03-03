using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.BirdGame
{
    public class Bird : MonoBehaviour
    {
        public static event UnityAction Crashed;

        [SerializeField]
        private AudioClip flap;

        [SerializeField]
        private float velocity_Y = 1;

        [SerializeField]
        private float velocity_X = 1;

        [SerializeField]
        private float _deltaX = 1;
        [SerializeField]
        private float _deltaY = 1;

        [SerializeField]
        private KeyCode _flapKeyCode = KeyCode.Space;


        private Rigidbody2D rb;

        private Vector3 _startPosition;
        private Quaternion _startRotatiton;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
            _startRotatiton = transform.rotation;
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            Crashed?.Invoke();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_flapKeyCode))
            {
                rb.velocity = Vector2.up * velocity_Y;
                AudioSource.PlayClipAtPoint(flap, Vector3.zero);
            }
            rb.transform.position += Vector3.right * velocity_X;

        }


        public void Reset()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotatiton;
        }
    }

}