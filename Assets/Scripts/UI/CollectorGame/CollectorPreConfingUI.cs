using PhysRehab.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class CollectorPreConfingUI : VisibleBase
    {
        [SerializeField]
        private Toggle _toggle_mirrorView;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Btn_StartLevel_Click()
        {
            CollectorGameScene.Gameplay.StartLevel();
        }
        public void Toggle_MirrorView_ValueChanged()
        {

        }
    }
}