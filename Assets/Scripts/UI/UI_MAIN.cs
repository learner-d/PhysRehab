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
        private CollectorUI _collectorUi;
        [SerializeField]
        private CopycatDevUi _copycatUi;
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
            
            //Ensure canvases activation
            
            //_collectorUi.gameObject.SetActive(true);
            
            _dialogs.gameObject.SetActive(true);
            _copycatUi.gameObject.SetActive(true);
            _genericUi.gameObject.SetActive(true);
            if (_isLoaded == false)
            {
                //Delete mockup image
                Destroy(_collectorUi.GetComponent<Image>());

                //Delete mockup image
                Destroy(_copycatUi.GetComponent<Image>());

                DontDestroyOnLoad(_collectorUi.gameObject);
                DontDestroyOnLoad(_copycatUi.gameObject);
                DontDestroyOnLoad(_genericUi.gameObject);
                DontDestroyOnLoad(_dialogs.gameObject);
                DontDestroyOnLoad(gameObject);
                Instance = this;
                _isLoaded = true;
                OnActiveGameChanged(_activeGame);
            }
        }

        private void Start()
        {
            HideGameUi();
        }

        public void HideGameUi()
        {
            _collectorUi.Hide();
            _copycatUi.Hide();
        }

        public void ShowGameUi(EGame game)
        {
            switch (game)
            {
                case EGame.Collector:
                    HideGameUi();
                    _collectorUi.Show();
                    break;
                case EGame.Copycat:
                    HideGameUi();
                    _copycatUi.Show();
                    break;
                case EGame.FlappyBird:
                    break;
                default:
                    break;
            }
        }
    } 
}
