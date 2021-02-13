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
            _name = "FlappyBirdGame";
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
            {
                IsLoaded = UI_MAIN.EnsureLoaded(this) == false;
                if (IsLoaded)
                {
                    _Loaded?.Invoke(this);
                }
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new FlappyBirdGameScene();
        }
    }
}