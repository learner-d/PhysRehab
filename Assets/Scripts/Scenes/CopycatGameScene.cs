using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    public class CopycatGameScene : GameScene
    {
        public static CopycatGameScene Instance { get; protected set; }
        public CopycatGameScene()
        {
            _name = "CopycatGame";
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            UiMain.Instance.ShowGameUi(EGame.Copycat);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        protected static void Initialize()
        {
            Instance = new CopycatGameScene();
        }
    }
}