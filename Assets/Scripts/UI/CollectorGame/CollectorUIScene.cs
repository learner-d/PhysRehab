using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CollectorUIScene : MonoBehaviour
    {
        public static CollectorUIScene Instance { get; private set; }
        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;
        public CollectorUI CollectorUI { get; private set; }

        public static bool EnsureLoaded()
        {
            if (_isLoaded == false)
            {
                SceneManager.LoadScene("CollectorUIScene", LoadSceneMode.Additive);

                return true;
            }

            return false;
        }

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