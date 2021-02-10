using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class CollectorPreConfingUI : VisibleBase
    {
        public static CollectorPreConfingUI Instance { get; private set; }
        [SerializeField]
        private Toggle _toggle_mirrorView;

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }

        public void Btn_StartLevel_Click()
        {
            GoodsCollectorScene.Gameplay.StartLevel();
        }
        public void Toggle_MirrorView_ValueChanged()
        {

        }
    }
}