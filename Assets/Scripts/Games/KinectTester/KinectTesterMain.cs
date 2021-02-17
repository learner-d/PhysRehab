using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.KinectTester
{
    public class KinectTesterMain : MonoBehaviour
    {
        public event UnityAction Loaded;

        public static KinectTesterMain Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            Loaded += OnLoaded;
            Loaded?.Invoke();
        }

        private void OnLoaded()
        {
            StatusText.Instance.Text = "Початок тестування:\nПіднесіть праву руку до точки";
        }
    }

}