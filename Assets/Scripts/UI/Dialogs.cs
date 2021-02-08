using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat.UI;
using PhysRehab.UI;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    private Canvas _canvas;
    private Fader _fader;
    private PoseSavingPanel _poseSavingPanel;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _fader = GetComponent<Fader>();
        _poseSavingPanel = GetComponentInChildren<PoseSavingPanel>();
    }
}
