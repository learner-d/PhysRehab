using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class CopycatGameScene : GameScene
    {
        public static CopycatGameScene Instance { get; protected set; }
        public CopycatGameScene()
        {
            _name = "CopycatGame";
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
            {
                IsActive = UI_MAIN.EnsureLoaded(this) == false;
                if (IsActive)
                {
                    _Loaded?.Invoke(this);
                }
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new CopycatGameScene();
        }
    }
}