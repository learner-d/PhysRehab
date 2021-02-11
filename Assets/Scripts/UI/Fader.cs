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
        private Image _faderImg;

        [SerializeField]
        [Range(0, 1)]
        private float _fading;

        [SerializeField]
        private bool _visible = true;

        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                UpdateFading();
            }
        }

        public float Fading
        {
            get => _fading;
            set
            {
                if (value < 0 || value > 1) return;

                _fading = value;
                UpdateFading();
            }
        }


        protected void Awake()
        {
            _faderImg = GetComponent<Image>();
        }

        protected void UpdateFading()
        {
            _faderImg.enabled = _visible && Math.Abs(_fading) > float.Epsilon;
            Color oldColor = _faderImg.color;
            _faderImg.color = new Color(0, 0, 0, _fading);
        }

        private void Update()
        {
            if (Application.isPlaying == false)
            {
                UpdateFading();
            }
        }

        public void Show()
        {
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }
    } 
}
