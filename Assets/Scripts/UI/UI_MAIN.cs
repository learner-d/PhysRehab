using System;
using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat;
using PhysRehab.Core;
using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class UI_MAIN : MonoBehaviour
    {
        public static UI_MAIN Instance { get; private set; }

        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;

        private EGame _activeGame = EGame.None;
        public EGame ActiveGame {
            get => _activeGame;
            set {
                _activeGame = value;
                ShowGameUi(value);
            }
        }

        [SerializeField]
        private CollectorUI _collectorUi;
        public CollectorUI CollectorUI => _collectorUi;

        [SerializeField]
        private CopycatDevUi _copycatUi;
        public CopycatDevUi CopycatDevUi => _copycatUi;

        [SerializeField]
        private BirdUI _birdUi;
        public BirdUI BirdUI => _birdUi;

        [SerializeField]
        private GenericUI _genericUi;
        public GenericUI GenericUI => _genericUi;

        [SerializeField]
        private Dialogs _dialogs;
        public Dialogs Dialogs => _dialogs;

        [SerializeField]
        private UiGameLoader _gameLoader;

        private static GameScene _sceneToLoad = null;

        /// <summary>
        /// Not supporting LoadSceneMode.Additive
        /// </summary>
        /// <returns>whether is scene wasn't previously loaded</returns>
        public static bool EnsureLoaded(GameScene loadNext = null)
        {
            if (_isLoaded == false)
            {
                SceneManager.LoadScene("MainUIScene");
                Debug.Log("UI Loaded");

                _sceneToLoad = loadNext;

                return true;
            }

            return false;
        }

        private void Awake()
        {
            Debug.Assert(_collectorUi != null);
            Debug.Assert(_copycatUi != null);
            Debug.Assert(_birdUi != null);
            Debug.Assert(_genericUi != null);
            Debug.Assert(_dialogs != null);
            Debug.Assert(_gameLoader != null);
            
            //Ensure canvases activation
            
            _collectorUi.gameObject.SetActive(true);
            _dialogs.gameObject.SetActive(true);
            _copycatUi.gameObject.SetActive(true);
            _birdUi.gameObject.SetActive(true);

            _genericUi.gameObject.SetActive(true);
            if (_isLoaded == false)
            {
                //Delete mockup image
                Destroy(_collectorUi.GetComponent<Image>());

                //Delete mockup image
                Destroy(_copycatUi.GetComponent<Image>());

                //Delete mockup image
                Destroy(_birdUi.GetComponent<Image>());

                DontDestroyOnLoad(_collectorUi.gameObject);
                DontDestroyOnLoad(_copycatUi.gameObject);
                DontDestroyOnLoad(_birdUi.gameObject);
                DontDestroyOnLoad(_genericUi.gameObject);
                DontDestroyOnLoad(_dialogs.gameObject);
                DontDestroyOnLoad(_gameLoader);
                DontDestroyOnLoad(gameObject);

                Instance = this;
                _isLoaded = true;

                //OnActiveGameChanged(_activeGame);

                if (_sceneToLoad != null)
                {
                    _sceneToLoad.EnsureLoaded();
                    _sceneToLoad = null;
                }
            }
        }

        public void HideGameUi()
        {
            _collectorUi.Hide();
            _copycatUi.Hide();
            _birdUi.Hide();
            _genericUi.Hide();
            _dialogs.Hide();

            Debug.Log("UI Hidden");

        }

        public void ShowGameUi(EGame game)
        {
            HideGameUi();
            switch (game)
            {
                case EGame.Collector:
                    _collectorUi.Show();
                    break;
                case EGame.Copycat:
                    _copycatUi.Show();
                    break;
                case EGame.Bird:
                    _birdUi.Show();
                    break;
                default:
                    return;
            }
            _genericUi.Show();
            _dialogs.Show();
            Debug.Log($"Shown UI for {game}");
        }
    } 
}
