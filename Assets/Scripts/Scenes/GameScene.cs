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
        protected static string _name;
        public static string Name => _name;
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

        public static void EnsureLoaded()
        {
            if (IsLoaded == false)
                SceneManager.LoadScene(_name);
        }
    }
}
