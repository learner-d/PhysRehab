using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class GameScene
    {
        private GameScene _instance = null;

        public static string Name { get; }
        public static bool IsLoaded { get; private set; }

        static GameScene()
        {

        }
        
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
