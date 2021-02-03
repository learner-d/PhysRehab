using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIScript : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.root.Find("CollectorUI"));
        DontDestroyOnLoad(transform.root.Find("CopycatDevUI"));
    }
}
