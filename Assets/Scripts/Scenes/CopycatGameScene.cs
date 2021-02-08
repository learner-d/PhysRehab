using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class CopycatGameScene : GameScene
    {
        public const string Name = "CopycatGame";
        public static bool IsLoaded { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Initialize()
        {
            SceneManager.sceneLoaded += (scene, loadType) =>
            {
                if (scene.name == Name)
                    IsLoaded = true;
            };
            SceneManager.sceneUnloaded += (scene) =>
            {
                if (scene.name == Name)
                    IsLoaded = false;
            };
        }
    }
}