using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat;
using PhysRehab.Copycat.UI;
using PhysRehab.Core;
using PhysRehab.UI;
using PhysRehab.UI.CopycatGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.UI
{
    public class CopycatDevUi : VisibleBase
    {
        public PoseCapturerUI CapturerUI { get; private set; }
        public MultiCapturingUI MultiCapturingUI { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            CapturerUI = GetComponentInChildren<PoseCapturerUI>();
            MultiCapturingUI = GetComponentInChildren<MultiCapturingUI>();
        }

        public void Initialize()
        {
            CapturerUI.Initialize();
            MultiCapturingUI.Initialize();
        }

        public void Shutdown()
        {
            CapturerUI.Shutdown();
            MultiCapturingUI.Shutdown();
        }


        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            CapturerUI.Visible = _visible;
            if (_visible == false)
            {
                Dialogs.Instance.PoseSavingPanel.Hide();
                Dialogs.Instance.MultiCapturePanel.Hide();

                MultiCapturingUI.Hide();
            }
        }
    } 
}
