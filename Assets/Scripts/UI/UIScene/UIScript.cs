using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhysRehab;

namespace PhysRehab.UI
{
    enum EView
    {
        None, Generic, MainMenu, CollectorGame
    }
    public class UIScript : MonoBehaviour
    {
        [SerializeField] private GameObject _uiCanvasObj;
                         private Canvas     _uiCanvas;
        [SerializeField] private GameObject _genericObj;
        [SerializeField] private GameObject _mainMenuObj;
        [SerializeField] private GameObject _collectorGameObj;
        [SerializeField] private GameObject _copycatGameObj;
        [SerializeField] private GameObject _birdGameObj;

        #region Methods
        public void Show()
        {
            _uiCanvasObj.SetActive(true);
        }
        public void Hide()
        {
            _uiCanvasObj.gameObject.SetActive(false);
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
            if (_uiCanvasObj == null)
            {
                _uiCanvasObj = GameObject.Find("/UiCanvas");
                _uiCanvas = _uiCanvasObj.GetComponent<Canvas>();
                if (_uiCanvasObj == null || _uiCanvas == null)
                {
                    throw new System.NullReferenceException($"{nameof(_uiCanvasObj)} and/or {nameof(_uiCanvas)} is null.");
                }
            }
            if (_genericObj == null)
            {
                _genericObj = GameObject.Find("/UiCanvas/Generic");
                if (_genericObj == null)
                {
                    throw new System.NullReferenceException($"{nameof(_genericObj)} is null.");
                }
            }
            if (_genericObj == null)
            {
                _genericObj = GameObject.Find("/UiCanvas/Generic");
                if (_genericObj == null)
                {
                    throw new System.NullReferenceException($"{nameof(_genericObj)} is null.");
                }
            }
            Program.Ui = this;
        }
    } 
}
