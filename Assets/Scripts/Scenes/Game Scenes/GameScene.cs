using PhysRehab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysRehab.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public abstract class GameScene
    {
        protected string _name;
        public string Name => _name;
        public bool IsLoaded { get; protected set; }

        protected UnityAction<GameScene> _Loaded;
        public event UnityAction<GameScene> Loaded
        {
            add => _Loaded += value;
            remove => _Loaded -= value;
        }

        protected UnityAction<GameScene> _UnLoaded;
        public event UnityAction<GameScene> Unloaded
        {
            add => _UnLoaded += value;
            remove => _UnLoaded -= value;
        }

        protected GameScene()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_SceneLoaded;
            SceneManager.sceneUnloaded += SceneManager_SceneUnloaded;
        }

        protected virtual void OnActiveSceneChanged(Scene prevScene, Scene newScene)
        {
            
        }

        private void SceneManager_SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
                OnSceneLoaded(scene, mode);
        }

        private void SceneManager_SceneUnloaded(Scene scene)
        {
            if (scene.name == Name)
                OnSceneUnloaded(scene);
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            IsLoaded = true;
            Program.ResolveStaticProperties(GetType());
            _Loaded?.Invoke(this);
            Console.WriteLine();
        }

        protected virtual void OnSceneUnloaded(Scene scene) 
        {
            IsLoaded = false;
            _UnLoaded?.Invoke(this);
            Program.ClearStaticProperties(GetType());
        }

        public virtual void EnsureLoaded()
        {
            if (IsLoaded == false)
                SceneManager.LoadScene(_name);
        }

        public virtual void Unload()
        {
            if(IsLoaded == true)
                SceneManager.UnloadScene(_name);
        }
    }
}
