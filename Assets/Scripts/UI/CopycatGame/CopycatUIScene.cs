using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CopycatUIScene : MonoBehaviour
    {
        public static CopycatUIScene Instance { get; private set; }
        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;
        public CopycatDevUi CopycatDevUi { get; private set; }

        public static bool EnsureLoaded()
        {
            if (_isLoaded == false)
            {
                SceneManager.LoadScene("CopycatUIScene", LoadSceneMode.Additive);

                return true;
            }

            return false;
        }

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

                UI_MAIN.EnsureLoaded();
            }
        }

        private void OnDestroy()
        {
            _isLoaded = false;
        }
    } 
}
