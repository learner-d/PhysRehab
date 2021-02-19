using System.Collections;
using System.Collections.Generic;
using PhysRehab.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CollectorUIScene : MonoBehaviour
    {
        public const string SceneName = "CollectorUIScene";
        public static CollectorUIScene Instance { get; private set; }

        private static bool _isLoaded = false;
        public static bool IsSceneLoaded => SceneManagerExt.IsSceneLoaded(SceneName);
        public CollectorUI CollectorUI { get; private set; }

        private void Awake()
        {
            if (_isLoaded == false)
            {
                CollectorUI = FindObjectOfType<CollectorUI>(true);
                Debug.Assert(CollectorUI != null);
                //Delete mockup image
                Destroy(CollectorUI.GetComponent<Image>());
                DontDestroyOnLoad(CollectorUI.gameObject);

                DontDestroyOnLoad(gameObject);
                Instance = this;
                _isLoaded = true;

                //Ensure canvases activation
                CollectorUI.gameObject.SetActive(true);

                //UI_MAIN.EnsureLoaded();
            }
        }

        private void OnDestroy()
        {
            _isLoaded = false;
        }
    }

}