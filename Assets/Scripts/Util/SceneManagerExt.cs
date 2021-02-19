using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Util
{
    public static class SceneManagerExt
    {
        public static Scene[] LoadedScenes => GetLoadedScenes();
        public static Scene[] GetLoadedScenes()
        {
            Scene[] scenes = new Scene[SceneManager.sceneCount];
            for (int i = 0; i < scenes.Length; i++)
                scenes[i] = SceneManager.GetSceneAt(0);
            return scenes;
        }

        public static bool IsSceneLoaded(string sceneName)
            => LoadedScenes.Select(scene => scene.name).Contains(sceneName);
    } 
}
