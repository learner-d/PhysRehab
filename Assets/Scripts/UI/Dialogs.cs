using System.Collections;
using System.Collections.Generic;
using PhysRehab.Copycat.UI;
using PhysRehab.UI;
using PhysRehab.UI.CollectorGame;
using UnityEngine;

public class Dialogs : VisibleBase
{
    public static Dialogs Instance { get; private set; }

    private Fader _fader;

    public PoseSavingPanel PoseSavingPanel { get; private set; }

    public MultiCapturePanel MultiCapturePanel { get; private set; }

    public StartLevelPanel StartLevelPanel { get; private set; }

    public LevelCompletePanel LevelCompletePanel { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _fader = GetComponent<Fader>();
        StartLevelPanel = GetComponentInChildren<StartLevelPanel>();
        LevelCompletePanel = GetComponentInChildren<LevelCompletePanel>();
        MultiCapturePanel = GetComponentInChildren<MultiCapturePanel>();
        PoseSavingPanel = GetComponentInChildren<PoseSavingPanel>();

        Instance = this;

    }
}
