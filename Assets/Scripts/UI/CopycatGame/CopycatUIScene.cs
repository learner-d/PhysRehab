using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI;
using PhysRehab.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CopycatUIScene : MonoBehaviour
    {
        public static CopycatUIScene Instance { get; private set; }
        public const string SceneName = "CopycatUIScene";
        
        private static bool _isLoaded = false;
        public static bool IsSceneLoaded => SceneManagerExt.IsSceneLoaded(SceneName) || _isLoaded;
        public CopycatDevUi CopycatDevUi { get; private set; }

        private void Awake()
        {
            if (_isLoaded == false)
            {
                CopycatDevUi = FindObjectOfType<CopycatDevUi>(true);
                Debug.Assert(CopycatDevUi != null);
                //Delete mockup image
                Destroy(CopycatDevUi.GetComponent<Image>());
                DontDestroyOnLoad(CopycatDevUi.gameObject);

                DontDestroyOnLoad(gameObject);
                Instance = this;
                _isLoaded = true;

                //Ensure canvases activation
                CopycatDevUi.gameObject.SetActive(true);

                //UI_MAIN.EnsureLoaded();
            }
        }

        private void OnDestroy()
        {
            _isLoaded = false;
        }
    } 
}
