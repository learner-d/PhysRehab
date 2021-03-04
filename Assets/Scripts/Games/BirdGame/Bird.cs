using System.Collections;
using System.Collections.Generic;
using PhysRehab.Generic;
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

        private Rigidbody2D _rigidBody;
        private FlapGesture _flapGesture;

        private Vector3 _startPosition;
        private Quaternion _startRotatiton;

        public bool IsAlive { get; private set; } = true;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _flapGesture = FindObjectOfType<FlapGesture>();
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
            _startRotatiton = transform.rotation;
            //Time.fixedDeltaTime = 1 / 30;
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            IsAlive = false; 
            Crashed?.Invoke();
        }

        private void Update()
        {
            if (IsAlive)
            {
                if (Input.GetKeyDown(_flapKeyCode) || _flapGesture.IsRecognised())
                {
                    _rigidBody.velocity = Vector2.up * velocity_Y;
                    if (flap != null)
                        AudioSource.PlayClipAtPoint(flap, Vector3.zero);
                }
                _rigidBody.transform.position += Vector3.right * velocity_X; 
            }
        }


        public void ResetIt()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotatiton;
            IsAlive = true;
        }
    }

}