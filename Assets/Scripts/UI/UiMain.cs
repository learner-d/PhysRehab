using System;
using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class UiMain : MonoBehaviour
    {
        public static UiMain Instance { get; private set; }
        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;

        [SerializeField]
        private EGame _activeGame = EGame.None;
        public EGame ActiveGame {
            get => _activeGame;
            set {
                OnActiveGameChanged(value);
                _activeGame = value;
            }
        }

        
        [SerializeField]
        private Canvas _collectorUi;
        [SerializeField]
        private Canvas _copycatUi;
        [SerializeField]
        private Canvas _genericUi;
        [SerializeField]
        private Dialogs _dialogs;

        private static void OnActiveGameChanged(EGame value)
        {
            switch (value)
            {
                case EGame.Collector:
                    SceneManager.LoadScene("GoodsCollectorGame");
                    break;
                case EGame.Copycat:
                    CopycatGameScene.Instance.EnsureLoaded();
                    break;
                case EGame.FlappyBird:
                    SceneManager.LoadScene("BirdGame");
                    break;
                default:
                    break;
            }
        }

        private void Awake()
        {
            Debug.Assert(_collectorUi != null);
            Debug.Assert(_copycatUi != null);
            Debug.Assert(_genericUi != null);
            Debug.Assert(_dialogs != null);
            if (_isLoaded == false)
            {
                //Ensure canvases activation
                _collectorUi.gameObject.SetActive(true);
                _copycatUi.gameObject.SetActive(true);
                _genericUi.gameObject.SetActive(true);
                _dialogs.gameObject.SetActive(true);

                //Delete mockup image
                Destroy(_collectorUi.GetComponent<Image>());

                //Delete mockup image
                Destroy(_copycatUi.GetComponent<Image>());

                DontDestroyOnLoad(_collectorUi.gameObject);
                DontDestroyOnLoad(_copycatUi.gameObject);
                DontDestroyOnLoad(_genericUi.gameObject);
                DontDestroyOnLoad(_dialogs.gameObject);
                DontDestroyOnLoad(gameObject);
                HideGameUi();
                Instance = this;
                _isLoaded = true;
                OnActiveGameChanged(_activeGame);
            }
        }

        public void HideGameUi()
        {
            _collectorUi.enabled = false;
            _copycatUi.enabled = false;
        }

        public void ShowGameUi(EGame game)
        {
            switch (game)
            {
                case EGame.Collector:
                    HideGameUi();
                    _collectorUi.enabled = true;
                    break;
                case EGame.Copycat:
                    HideGameUi();
                    _copycatUi.enabled = true;
                    break;
                case EGame.FlappyBird:
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Break!");
            }
        }
    } 
}
