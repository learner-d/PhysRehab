using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhysRehab;

namespace PhysRehab.UI
{
    public class UIScript : MonoBehaviour
    {
        [SerializeField] private Canvas _uiCanvas;

        #region Methods
        public void Show()
        {
            _uiCanvas.gameObject.SetActive(true);
        }
        public void Hide()
        {
            _uiCanvas.gameObject.SetActive(false);
        }
        #endregion

        #region Event Handlers
        public void GoToMenuBtn_Click()
        {
            Program.GoToMainMenu();
        }
        #endregion

        private void Awake()
        {
            if (_uiCanvas == null)
            {
                _uiCanvas = GameObject.Find("UiCanvas").GetComponent<Canvas>();
                if (_uiCanvas == null)
                {
                    throw new System.NullReferenceException($"{nameof(_uiCanvas)} is null.");
                }
            }
        }
    } 
}
