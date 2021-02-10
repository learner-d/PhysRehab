﻿using PhysRehab.UI;
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
                return;
                if(newScene.name == Name)
                    Program.LoadUi();
            };
            SceneManager.sceneLoaded += (scene, loadType) =>
            {
                if (scene.name == Name)
                    IsLoaded = true;
            };
            SceneManager.sceneUnloaded += (scene) =>
            {
                if (scene.name == Name)
                {
                    UI_MAIN.Instance.HideGameUi();
                    IsLoaded = false;
                }
            };
        }

        public void EnsureLoaded()
        {
            if (IsLoaded == false)
                SceneManager.LoadScene(_name);
        }
    }
}
