using System;
using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.Scenes;
using UnityEngine;

namespace PhysRehab.UI
{
    public class UiGameLoader : MonoBehaviour
    {
        private static bool _isLoaded = false;
        
        [SerializeField]
        private EGame _loadGame = EGame.None;

        [SerializeField]
        private bool _goToMenu = false;

        private void Awake()
        {
            if (_isLoaded == false)
            {
                MainMenuScene.Instance.Loaded += MainMenuScene_Loaded;
                MainMenuScene.Instance.Unloaded += MainMenuScene_Unloaded;

                CollectorGameScene.Instance.Loaded += CollectorGameScene_Loaded;
                CollectorGameScene.Instance.Unloaded += CollectorGameScene_Unloaded;
                CopycatGameScene.Instance.Loaded += CopycatGameScene_Loaded;
                CopycatGameScene.Instance.Unloaded += CopycatGameScene_Unloaded;
                BirdGameScene.Instance.Loaded += BirdGameScene_Loaded;
                BirdGameScene.Instance.Unloaded += BirdGameScene_UnLoaded;
                _isLoaded = true;
            }
        }

        private void Start()
        {
            LoadSceneIfNeeded();
        }

        public void Clear()
        {
            _loadGame = EGame.None;
            _goToMenu = false;
        }

        private void LoadSceneIfNeeded()
        {
            if(MainMenuScene.Instance.IsActive)
                return;

            if (_goToMenu)
            {
                MainMenuScene.Instance.EnsureLoaded();
                _goToMenu = true;
                return;
            }

            switch (_loadGame)
            {
                case EGame.Collector:
                    CollectorGameScene.Instance.EnsureLoaded();
                    break;
                case EGame.Copycat:
                    CopycatGameScene.Instance.EnsureLoaded();
                    break;
                case EGame.Bird:
                    BirdGameScene.Instance.EnsureLoaded();
                    break;
                default:
                    break;
            }

            _loadGame = EGame.None;
        }

        private void MainMenuScene_Loaded(GameScene arg0)
        {
            UI_MAIN.Instance.ActiveGame = EGame.None;
        }

        private void MainMenuScene_Unloaded(GameScene arg0)
        {
            
        }

        private void CollectorGameScene_Loaded(GameScene gameScene)
        {
            CollectorUI.Instance.Initialize();
            UI_MAIN.Instance.ActiveGame = EGame.Collector;
        }

        private void CollectorGameScene_Unloaded(GameScene gameScene)
        {
            CollectorUI.Instance.Shutdown();
        }

        private void CopycatGameScene_Loaded(GameScene gameScene)
        {
            CopycatDevUi.Instance.Initialize();
            UI_MAIN.Instance.ActiveGame = EGame.Copycat;
        }

        private void CopycatGameScene_Unloaded(GameScene gameScene)
        {
            CopycatDevUi.Instance.Shutdown();
        }

        private void BirdGameScene_Loaded(GameScene gameScene)
        {
            
            BirdUI.Instance.Initialize();
            UI_MAIN.Instance.ActiveGame = EGame.Bird;
        }

        private void BirdGameScene_UnLoaded(GameScene gameScene)
        {
            BirdUI.Instance.Shutdown();
        }
    } 
}
