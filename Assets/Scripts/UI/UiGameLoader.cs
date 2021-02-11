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
                _isLoaded = true;

                LoadSceneIfNeeded();
            }
        }

        private void LoadSceneIfNeeded()
        {
            if (_goToMenu)
            {
                MainMenuScene.Instance.EnsureLoaded();
                _goToMenu = false;
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
                case EGame.FlappyBird:
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
            UI_MAIN.Instance.CollectorUI.Initialize();
            UI_MAIN.Instance.ActiveGame = EGame.Collector;
        }

        private void CollectorGameScene_Unloaded(GameScene gameScene)
        {
            UI_MAIN.Instance.CollectorUI.Shutdown();
        }

        private void CopycatGameScene_Loaded(GameScene gameScene)
        {
            UI.UI_MAIN.Instance.CopycatDevUi.Initialize();
            UI_MAIN.Instance.ActiveGame = EGame.Copycat;
        }

        private void CopycatGameScene_Unloaded(GameScene gameScene)
        {
            UI_MAIN.Instance.CopycatDevUi.Shutdown();
        }
    } 
}
