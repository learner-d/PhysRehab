using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PhysRehab.UI.BirdGame
{

    public class BirdWinPanel : DialogPanelBase
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void ShowWinPanel()
        {
            Program.Pause();
            Show();
        }
    }
}