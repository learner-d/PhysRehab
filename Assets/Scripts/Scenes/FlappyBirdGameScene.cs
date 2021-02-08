using System;
using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class FlappyBirdGameScene : GameScene
    {
        public static FlappyBirdGameScene Instance { get; protected set; }
        public FlappyBirdGameScene()
        {
            _name = "BirdGame";
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            UiMain.Instance.ShowGameUi(EGame.FlappyBird);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        protected static void Initialize()
        {
            Instance = new FlappyBirdGameScene();
        }
    }
}