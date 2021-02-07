using System.Collections;
using System.Collections.Generic;
using PhysRehab.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class UiMain : MonoBehaviour
    {
        public static UiMain Instance { get; private set; }
        private static bool _isLoaded = false;
        public static bool IsLoaded => _isLoaded;

        [SerializeField]
        private Canvas _collectorUi;
        [SerializeField]
        private Canvas _copycatUi;
        [SerializeField]
        private Canvas _genericUi;
        [SerializeField]
        private Dialogs _dialogs;
        private void Awake()
        {
            Debug.Assert(_collectorUi != null);
            Debug.Assert(_copycatUi != null);
            Debug.Assert(_genericUi != null);
            Debug.Assert(_dialogs != null);
            if (_isLoaded == false)
            {
                //Delete mockup image
                Destroy(_collectorUi.GetComponent<Image>());

                //Delete mockup image
                Destroy(_copycatUi.GetComponent<Image>());

                DontDestroyOnLoad(_collectorUi.gameObject);
                DontDestroyOnLoad(_copycatUi.gameObject);
                DontDestroyOnLoad(_genericUi.gameObject);
                DontDestroyOnLoad(_dialogs.gameObject);
                DontDestroyOnLoad(gameObject);
                HideGameUi();
                Instance = this;
                _isLoaded = true;
#if DEBUG
                SceneManager.LoadScene("CopycatGame");
#endif
            }
        }

        public void HideGameUi()
        {
            _collectorUi.gameObject.SetActive(false);
            _copycatUi.gameObject.SetActive(false);
        }

        public void ShowGameUi(EGame game)
        {
            switch (game)
            {
                case EGame.Collector:
                    HideGameUi();
                    _collectorUi.gameObject.SetActive(true);
                    break;
                case EGame.Copycat:
                    HideGameUi();
                    _copycatUi.gameObject.SetActive(true);
                    break;
                case EGame.FlappyBird:
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Break!");
            }
        }
    } 
}
