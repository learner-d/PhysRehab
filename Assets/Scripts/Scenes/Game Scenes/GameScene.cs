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
        public bool IsActive { get; protected set; }

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
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        protected virtual void OnActiveSceneChanged(Scene prevScene, Scene newScene)
        {
            
        }

        protected abstract void OnSceneLoaded(Scene scene, LoadSceneMode mode);

        protected virtual void OnSceneUnloaded(Scene scene) 
        {
            if (scene.name == Name)
            {
                IsActive = false;
                _UnLoaded?.Invoke(this);
            }
        }

        public virtual void EnsureLoaded()
        {
            if (IsActive == false)
                SceneManager.LoadScene(_name);
        }
    }
}
