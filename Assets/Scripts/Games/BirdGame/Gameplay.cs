using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class Gameplay : MonoBehaviour
    {
        public Bird Player { get; private set; }

        private void Awake()
        {
            Player = FindObjectOfType<Bird>();
        }

        public void Reset()
        {
            Player.ResetIt();
        }
    }
}