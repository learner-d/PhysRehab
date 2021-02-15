using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Core;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.UI
{
    public class BirdUI : VisibleBase
    {
   

        protected override void Awake()
        {
            base.Awake();
           
        }

        public void Initialize()
        {
         
        }

        public void Shutdown()
        {
          
        }


        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if (_visible == false)
            {
                UI_MAIN.Instance.Dialogs.StartLevelPanel.Hide();
                UI_MAIN.Instance.GenericUI.PausePanel.Hide();
                UI_MAIN.Instance.Dialogs.LevelCompletePanel.Hide();
            }
        }
    }
}