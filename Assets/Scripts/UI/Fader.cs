using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class Fader : MonoBehaviour
    {
        public static Fader Instance { get; private set; }
        private Canvas _canvas;
        private Image _faderImg;
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            _faderImg = GetComponent<Image>();
            if (_faderImg == null)
                _faderImg = gameObject.AddComponent<Image>(); 
            Instance = this;
            Fading(0);
        }

        public void Fading(float amount)
        {
            if (amount < 0 || amount > 1)
                throw new System.ArgumentOutOfRangeException(nameof(amount));

            _faderImg.enabled = Math.Abs(amount) > float.Epsilon;
            Color oldColor = _faderImg.color;
            _faderImg.color = new Color(oldColor.r, oldColor.g, oldColor.b, amount);
        }
    } 
}
