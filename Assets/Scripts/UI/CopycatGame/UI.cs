using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.Copycat.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private Image _faderImg;

        public static UI Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Fading(float amount)
        {
            if (amount < 0 || amount > 1)
                throw new System.ArgumentOutOfRangeException(nameof(amount));
            
            _faderImg.gameObject.SetActive(amount != 0);
            Color oldColor = _faderImg.color;
            _faderImg.color = new Color(oldColor.r, oldColor.g, oldColor.b, amount);
        }
    } 
}
