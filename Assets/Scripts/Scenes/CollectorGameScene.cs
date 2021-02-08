using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class CollectorGameScene : GameScene
    {
        public static CollectorGameScene Instance { get; protected set; }
        public CollectorGameScene()
        {
            _name = "GoodsCollectorGame";
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            UiMain.Instance.ShowGameUi(EGame.Collector);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        protected static void Initialize()
        {
            Instance = new CollectorGameScene();
        }
    }
}