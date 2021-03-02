using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float _camera_deltaX = 1;
        [SerializeField]
        private float _camera_deltaY = 1;

        private Bird _bird;
        private void Awake()
        {
            _bird = FindObjectOfType<Bird>();
        }

        private void Update()
        {
            transform.position
                = new Vector3(_bird.transform.position.x + _camera_deltaX, _bird.transform.position.y,
                    transform.position.z);
        }
    } 
}
