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
            }
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
            UI_MAIN.Instance.CollectorUI.WireupGameEvents();
            UI_MAIN.Instance.ActiveGame = EGame.Collector;
        }

        private void CopycatGameScene_Loaded(GameScene gameScene)
        {
            UI_MAIN.Instance.ActiveGame = EGame.Copycat;
        }

        private void CollectorGameScene_Unloaded(GameScene gameScene)
        {
            UI_MAIN.Instance.CollectorUI.UnwireupGameEvents();
        }
        private void CopycatGameScene_Unloaded(GameScene gameScene)
        {
            
        }
    } 
}
