using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PhysRehab.Scenes
{
    public class MainMenuScene : GameScene
    {
        public static MainMenuScene Instance { get; protected set; }
        public MainMenuScene()
        {
            _name = "MainMenuScene";
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new MainMenuScene();
        }
    }
}
