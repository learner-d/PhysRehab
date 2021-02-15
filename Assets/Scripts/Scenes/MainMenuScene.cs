using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class MainMenuScene : GameScene
    {
        public static MainMenuScene Instance { get; protected set; }
        public MainMenuScene()
        {
            _name = "MainMenuScene";
        }

        /// <summary>
        /// Not supporting LoadSceneMode.Additive
        /// </summary>
        /// <param name="mode">Not supporting LoadSceneMode.Additive</param>
        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
            {
                IsActive = UI_MAIN.EnsureLoaded(this) == false;
                if(IsActive)
                    _Loaded?.Invoke(this);
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            Instance = new MainMenuScene();
        }
    }
}
