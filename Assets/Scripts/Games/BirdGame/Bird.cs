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
        private Vector2 _velocity = Vector2.right;

        [SerializeField]
        private Vector2 _flapForce = new Vector2(1, 1);
        [SerializeField]
        private ForceMode2D _flapForceMode = ForceMode2D.Impulse;

        [SerializeField]
        private KeyCode _flapKeyCode = KeyCode.Space;

        private Rigidbody2D _rigidBody;
        private FlapGesture _flapGesture;

        private Vector3 _startPosition;
        private Quaternion _startRotatiton;

        private int _flapCount = 0;

        public bool IsAlive { get; private set; } = true;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _flapGesture = FindObjectOfType<FlapGesture>();
            System.Console.WriteLine();
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
                    MakeFlap();
                _rigidBody.position += _velocity;
            }
        }

        private void MakeFlap()
        {
            Debug.Log($"Flap {++_flapCount}");

            _rigidBody.velocity = Vector2.zero;
            _rigidBody.AddForce(_flapForce, _flapForceMode);
            if (flap != null)
                MainAudioSource.Instance.PlaySound(flap);
        }


        public void Clear()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotatiton;
            _flapCount = 0;
            IsAlive = true;
        }
    }

}