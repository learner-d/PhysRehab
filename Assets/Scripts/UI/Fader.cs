using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    [RequireComponent(typeof(Image))]
    [ExecuteInEditMode]
    public class Fader : MonoBehaviour
    {
        public static Fader Instance { get; private set; }
        [SerializeField]
        [Range(0, 1)]
        private float _fading;

        private Canvas _canvas;
        private Image _faderImg;

        public bool IsVisible { get; set; } = true;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            _faderImg = GetComponent<Image>();
            if (_faderImg == null)
                _faderImg = gameObject.AddComponent<Image>(); 
            IsVisible = false;
            Instance = this;
        }

        private void UpdateFading(float amount)
        {
            if (amount < 0 || amount > 1)
                throw new System.ArgumentOutOfRangeException(nameof(amount));

            _faderImg.enabled = IsVisible && Math.Abs(amount) > float.Epsilon;
            Color oldColor = _faderImg.color;
            _faderImg.color = new Color(oldColor.r, oldColor.g, oldColor.b, amount);
        }

        private long _framesCount = 0;
        private void Update()
        {
            if (_framesCount++ % 10 == 0 || Application.isPlaying == false)
            {
                UpdateFading(_fading); 
            }
        }
    } 
}
