using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class CollectorGameScene : GameScene
    {
        public static CollectorGameScene Instance { get; protected set; }
        protected CollectorGameScene()
        {
            _name = "GoodsCollectorGame";
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new CollectorGameScene();
        }
    }
}