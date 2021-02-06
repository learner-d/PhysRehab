using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhysRehab.UI
{
    public class UiMain : MonoBehaviour
    {
        private Canvas _collectorUi;
        private Canvas _copycatUi;
        private bool _isLoaded = false;
        private void Awake()
        {
            _collectorUi = transform.root.Find("CollectorUI").GetComponent<Canvas>();
            _collectorUi.gameObject.SetActive(false);
            DontDestroyOnLoad(_collectorUi.gameObject);
            _copycatUi = transform.root.Find("CopycatDevUI").GetComponent<Canvas>();
            _copycatUi.gameObject.SetActive(false);
            DontDestroyOnLoad(_copycatUi.gameObject);
        }

        public static void OnAppStartup()
        {
            Program
        }
    } 
}
