using PhysRehab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.Scenes
{
    class KinectTesterScene : GameScene
    {
        public static KinectTesterScene Instance { get; private set; }
        public KinectTesterScene()
        {
            _name = "KinectTester";
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            Instance = new KinectTesterScene();
        }
    }
}
