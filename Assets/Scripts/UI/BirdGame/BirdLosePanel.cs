using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PhysRehab.UI.BirdGame
{

    public class BirdLosePanel : DialogPanelBase
    {
    
        protected override void Awake()
        {
            base.Awake();
        }

        public void ShowLosePanel()
        {
            Program.Pause();
            Show();
        }
    }
}