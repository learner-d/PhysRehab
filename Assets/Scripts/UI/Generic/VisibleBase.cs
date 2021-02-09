using UnityEngine;

namespace PhysRehab.UI
{
    [RequireComponent(typeof(Canvas))]
    [ExecuteInEditMode]
    public abstract class VisibleBase : MonoBehaviour
    {
        protected static VisibleBase _instance;

        protected Canvas _canvas;

        [SerializeField]
        protected bool _visible = true;
        public bool Visible => _visible;

        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _instance = this;
        }

        public virtual void Show()
        {
            _visible = true;
            UpdateVisibility();
        }

        public virtual void Hide()
        {
            _visible = false;
            UpdateVisibility();
        }

        protected virtual void Update()
        {
            if (Application.isPlaying == false)
                UpdateVisibility();
        }

        protected virtual void UpdateVisibility()
        {
            _canvas.enabled = _visible;
        }
    }
}