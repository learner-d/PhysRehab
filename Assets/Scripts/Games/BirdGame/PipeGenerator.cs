using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class PipeGenerator : MonoBehaviour
    {
        private Bird _player;

        private void Awake()
        {
            _player = FindObjectOfType<Bird>();
        }
    } 
}
