namespace PhysRehab.UI.CollectorGame
{
    public class PausePanel : DialogPanelBase
    {
        public static PausePanel Instance { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }
    }
}