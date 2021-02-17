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

        private bool _isRunning = false;

        private EGame _activeGame = EGame.None;
        public EGame ActiveGame {
            get => _activeGame;
            set {
                _activeGame = value;
                ShowGameUi(value);
            }
        }


        public GenericUI GenericUI { get; private set; }
        public Dialogs Dialogs { get; private set; }

        public UiGameLoader GameLoader { get; private set; }

        private static GameScene _sceneToLoad = null;

        /// <summary>
        /// Not supporting LoadSceneMode.Additive
        /// </summary>
        /// <returns>whether is scene wasn't previously loaded</returns>
        public static bool EnsureLoaded(GameScene loadNext = null)
        {
            CopycatUIScene.EnsureLoaded();
            CollectorUIScene.EnsureLoaded();
            BirdUIScene.EnsureLoaded();
            if (_isLoaded == false)
            {
                SceneManager.LoadScene("MainUIScene", LoadSceneMode.Additive);
                Debug.Log("Loading UI");

                if (loadNext != null)
                {
                    _sceneToLoad = loadNext; 
                }

                return true;
            }

            return false;
        }

        private void Awake()
        {
            CollectorUIScene.EnsureLoaded();
            BirdUIScene.EnsureLoaded();
            CopycatUIScene.EnsureLoaded();
            _isRunning = false;
            if (_isLoaded == false)
            {

                GenericUI = FindObjectOfType<GenericUI>(true);
                Debug.Assert(GenericUI != null);
                DontDestroyOnLoad(GenericUI.gameObject);

                Dialogs = FindObjectOfType<Dialogs>(true);
                Debug.Assert(Dialogs != null);
                DontDestroyOnLoad(Dialogs.gameObject);

                GameLoader = FindObjectOfType<UiGameLoader>(true);
                Debug.Assert(GameLoader != null);
                DontDestroyOnLoad(GameLoader);

                DontDestroyOnLoad(gameObject);

                Instance = this;
                _isLoaded = true;

                GenericUI.gameObject.SetActive(true);
                Dialogs.gameObject.SetActive(true);

                if (_sceneToLoad != null)
                {
                    _sceneToLoad.EnsureLoaded();
                    _sceneToLoad = null;
                }
            }
        }

        private void Start()
        {
            _isRunning = true;
            ShowGameUi(_activeGame);
        }

        public void ShowGameUi(EGame game)
        {
            if(_isRunning == false)
                return;

            HideGameUi();
            switch (game)
            {
                case EGame.Collector:
                    CollectorUI.Instance.Show();
                    break;
                case EGame.Copycat:
                    CopycatDevUi.Instance.Show();
                    break;
                case EGame.Bird:
                    BirdUI.Instance.Show();
                    break;
                case EGame.KinectTester:
                    break;
                default:
                    return;
            }
            GenericUI.Show();
            Dialogs.Show();
            Debug.Log($"Shown UI for {game}");
        }

        public void HideGameUi()
        {
            if (_isRunning == false)
                return;

            CollectorUI.Instance.Hide();
            CopycatDevUi.Instance.Hide();
            BirdUI.Instance.Hide();
            GenericUI.Hide();
            Dialogs.Hide();

            Debug.Log("UI Hidden");
        }
    } 
}
