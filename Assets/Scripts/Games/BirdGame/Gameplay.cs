using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    public class Gameplay : MonoBehaviour
    {
        public static Gameplay Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}