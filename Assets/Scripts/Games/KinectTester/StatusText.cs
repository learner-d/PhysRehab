using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.KinectTester
{
    [ExecuteInEditMode]
    public class StatusText : MonoBehaviour
    {
        private Text _textComponent;
        public static StatusText Instance { get; private set; }

        [SerializeField]
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                UpdateText();
            }
        }

        private void Awake()
        {
            _textComponent = GetComponent<Text>();
            Instance = this;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Application.isEditor)
            {
                UpdateText();
            }
        }

        private void UpdateText()
        {
            _textComponent.text = _text;
        }
    } 
}
