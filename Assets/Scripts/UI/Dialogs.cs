using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat.UI;
using PhysRehab.UI;
using UnityEngine;

public class Dialogs : VisibleBase
{
    private Fader _fader;
    private PoseSavingPanel _poseSavingPanel;

    protected override void Awake()
    {
        base.Awake();
        _fader = GetComponent<Fader>();
        _poseSavingPanel = GetComponentInChildren<PoseSavingPanel>();
    }
}
