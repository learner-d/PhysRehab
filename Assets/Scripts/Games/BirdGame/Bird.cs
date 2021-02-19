using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class Bird : MonoBehaviour
    {
        [SerializeField]
        private float _deltaX = 1;

        [SerializeField]
        private float _deltaY = 1;

        [SerializeField]
        private float _camera_deltaX = 1;

        [SerializeField]
        private float _camera_deltaY = 1;

        [SerializeField]
        private GameObject Pipe;
        [SerializeField]
        private GameObject End;

        private bool Win = false;

        private bool IsDead = false;

        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x + _deltaX, transform.position.y + _deltaY, transform.position.z);
            Camera.main.transform.position = new Vector3(transform.position.x + _camera_deltaX, transform.position.y, Camera.main.transform.position.z);

        }
    }

}