using PhysRehab.UI;
using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using PhysRehab.Collector;

namespace PhysRehab.Scenes
{
    public class CollectorGameScene : GameScene
    {
        public static Gameplay Gameplay { get; private set; }
        public static LevelManager LevelManager { get; private set; }
        public static PickupObserver PickupObserver { get; private set; }
        public static PickupSpawner PickupSpawner { get; private set; }
        public static ScoreCounter_old ScoreCounter { get; private set; }

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

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Name)
            {
                IsActive = UI_MAIN.EnsureLoaded(this) == false;
                if (IsActive)
                {
                    Program.ResolveStaticProperties<CollectorGameScene>();
                    _Loaded?.Invoke(this);
                }
            }
        }
        
        protected override void OnSceneUnloaded(Scene scene)
        {
            if (scene.name == Name)
            {
                IsActive = false;
                _UnLoaded?.Invoke(this);
                Program.ClearStaticProperties<CollectorGameScene>();
            }
        }
    }
}