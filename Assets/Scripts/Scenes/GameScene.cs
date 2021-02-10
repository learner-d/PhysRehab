using PhysRehab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public abstract class GameScene
    {
        protected string _name;
        public string Name => _name;
        public bool IsLoaded { get; protected set; }

        protected GameScene()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        protected virtual void OnActiveSceneChanged(Scene prevScene, Scene newScene)
        {
            return;
            if (newScene.name == Name)
                Program.LoadUi();
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
                IsLoaded = true;
        }

        protected virtual void OnSceneUnloaded(Scene scene) 
        {
            if (scene.name == Name)
            {
                UI_MAIN.Instance?.HideGameUi();
                IsLoaded = false;
            }
        }

        public void EnsureLoaded()
        {
            if (IsLoaded == false)
                SceneManager.LoadScene(_name);
            Program.LoadUi();
        }
    }
}
