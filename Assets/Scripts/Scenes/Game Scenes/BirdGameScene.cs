using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class BirdGameScene : GameScene
    {
        public static BirdGameScene Instance { get; protected set; }
        public BirdGameScene()
        {
            _name = "BirdGame";
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
            {
                IsActive = true;
                _Loaded?.Invoke(this);
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new BirdGameScene();
        }
    }
}