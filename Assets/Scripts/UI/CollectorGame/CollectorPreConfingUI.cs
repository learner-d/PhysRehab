using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI.CollectorGame
{
    public class CollectorPreConfingUI : VisibleBase
    {
        public static CollectorPreConfingUI Instance => (CollectorPreConfingUI)_instance;
        [SerializeField]
        private Toggle _toggle_mirrorView;

        public void Btn_StartLevel_Click()
        {
            GoodsCollectorScene.Gameplay.StartLevel();
        }
        public void Toggle_MirrorView_ValueChanged()
        {

        }
    }
}