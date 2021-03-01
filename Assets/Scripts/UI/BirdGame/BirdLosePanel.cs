using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PhysRehab.UI.BirdGame
{

    public class BirdLosePanel : DialogPanelBase
    {

        [SerializeField]
        private AudioClip _loseSound;
        public void ShowLosePanel()
        {
            Program.Pause();
            MainAudioSource.Instance.PlaySound(_loseSound);
            Show();
        }
    }
}