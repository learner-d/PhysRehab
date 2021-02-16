using PhysRehab.UI;
using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI.CollectorGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class BirdUIScene : MonoBehaviour
    {
        public static BirdUIScene Instance { get; private set; }
        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;
        public BirdUI BirdUI { get; private set; }

        public static bool EnsureLoaded()
        {
            if (_isLoaded == false)
            {
                SceneManager.LoadScene("BirdUIScene", LoadSceneMode.Additive);

                return true;
            }

            return false;
        }

        private void Awake()
        {
            if (_isLoaded == false)
            {
                BirdUI = FindObjectOfType<BirdUI>(true);
                Debug.Assert(BirdUI != null);
                //Delete mockup image
                Destroy(BirdUI.GetComponent<Image>());
                DontDestroyOnLoad(BirdUI.gameObject);

                DontDestroyOnLoad(gameObject);
                Instance = this;
                _isLoaded = true;

                //Ensure canvases activation
                BirdUI.gameObject.SetActive(true);

                //UI_MAIN.EnsureLoaded();
            }
        }

        private void OnDestroy()
        {
            _isLoaded = false;
        }
    }

}