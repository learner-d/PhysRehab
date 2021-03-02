using System.Collections;
using System.Collections.Generic;
using PhysRehab.BirdGame;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class BirdGameScene : GameScene
    {
        public static BirdGameScene Instance { get; protected set; }

        public static Gameplay Gameplay { get; private set; }

        public BirdGameScene()
        {
            _name = "BirdGame";
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new BirdGameScene();
        }
    }
}