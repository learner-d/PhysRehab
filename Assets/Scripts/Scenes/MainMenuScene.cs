using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            EnsureLoaded();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            Instance = new MainMenuScene();
        }
    }
}
