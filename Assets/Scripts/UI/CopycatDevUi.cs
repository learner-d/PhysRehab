using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        protected override void Awake()
        {
            base.Awake();
            CapturerUI = GetComponentInChildren<PoseCapturerUI>();
        }

        public void Initialize()
        {
            CapturerUI.Initialize();
        }

        public void Shutdown()
        {
            CapturerUI.Shutdown();
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            CapturerUI.Visible = _visible;
            if (_visible == false)
            {
                Dialogs.Instance.PoseSavingPanel.Hide();
                Dialogs.Instance.MultiCapturePanel.Hide();
            }
        }
    } 
}
