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
            SceneManager.activeSceneChanged += (prevScene, newScene) =>
            {
                if(newScene.name == _name)
                    OnScenePreLoad();
            };
            SceneManager.sceneLoaded += (scene, loadType) =>
            {
                if (scene.name == Name)
                    OnSceneLoaded();
            };
            SceneManager.sceneUnloaded += (scene) =>
            {
                if (scene.name == Name)
                    OnSceneUnloaded();
            };
        }

        public void EnsureLoaded()
        {
            if (IsLoaded == false)
                SceneManager.LoadScene(_name);
        }


        protected virtual void OnSceneLoaded()
        {
            IsLoaded = true;
        }

        protected virtual void OnSceneUnloaded()
        {
            IsLoaded = false;
        }

        protected virtual void OnScenePreLoad()
        {
            Program.LoadUi();
        }
    }
}
