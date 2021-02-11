using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat.UI;
using PhysRehab.UI;
using PhysRehab.UI.CollectorGame;
using UnityEngine;

public class Dialogs : VisibleBase
{
    private Fader _fader;

    public PoseSavingPanel PoseSavingPanel { get; private set; }

    public StartLevelPanel StartLevelPanel { get; private set; }

    public LevelCompletePanel LevelCompletePanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _fader = GetComponent<Fader>();
        StartLevelPanel = GetComponentInChildren<StartLevelPanel>();
        LevelCompletePanel = GetComponentInChildren<LevelCompletePanel>();
        
        PoseSavingPanel = GetComponentInChildren<PoseSavingPanel>();
    }
}
