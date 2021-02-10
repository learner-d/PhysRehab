using PhysRehab.UI.CollectorGame;

namespace PhysRehab.UI
{
    public class GenericUI : VisibleBase
    {
        public PausePanel PausePanel { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            PausePanel = GetComponentInChildren<PausePanel>();
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if(_visible == false)
                PausePanel.Hide();
        }
    }
}