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
        private float _deltaX = 1;
        [SerializeField]
        private float _deltaY = 1;

        [SerializeField]
        private KeyCode _flapKeyCode = KeyCode.Space;

        [SerializeField]
        private float _flapVelocityX = 1;
        [SerializeField]
        private float _flapVelocityY = 1;

        private Rigidbody2D _rigidbody;

        private Vector3 _startPosition;
        private Quaternion _startRotatiton;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _startPosition = transform.position;
            _startRotatiton = transform.rotation;
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            Crashed?.Invoke();
        }

        private void FixedUpdate()
        {
            if(Input.GetKeyDown(_flapKeyCode))
                MakeFlap();

            transform.position = new Vector3(transform.position.x + _deltaX, transform.position.y + _deltaY, transform.position.z);
        }

        private void MakeFlap()
        {
            _rigidbody.velocity = new Vector2(_flapVelocityX, _flapVelocityY);
        }

        public void Reset()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotatiton;
        }
    }

}