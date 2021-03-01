using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab
{
    public static class Main
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void BeforeSceneLoad()
        {
            Debug.Log("Before scene load");
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void AfterSceneLoad()
        {
            Debug.Log("After scene load");

            if (Application.isEditor)
            {
                if (CollectorUIScene.IsSceneLoaded)
                    UiGameLoader.LoadGame = EGame.Collector;
                else if (CopycatUIScene.IsSceneLoaded)
                    UiGameLoader.LoadGame = EGame.Copycat;
                else if (BirdUIScene.IsSceneLoaded)
                    UiGameLoader.LoadGame = EGame.Bird;
            }

            UI_MAIN.EnsureLoaded();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            
        }
    } 
}
