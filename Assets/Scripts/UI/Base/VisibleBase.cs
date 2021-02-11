using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    [RequireComponent(typeof(Canvas))]
    [ExecuteInEditMode]
    public abstract class VisibleBase : MonoBehaviour
    {
        protected Canvas _canvas;
        protected GraphicRaycaster _graphicRaycaster;
        protected VisibleBase _parent;

        [SerializeField]
        protected bool _visible = true;
        public bool Visible {
            get => _visible;
            set
            {
                _visible = value;
                UpdateVisibility();
            }
        }

        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _graphicRaycaster = GetComponent<GraphicRaycaster>();
        }

        protected virtual void OnEnable()
        {
            if (Application.isPlaying)
            {
                VisibleBase[] _children = GetComponentsInChildren<VisibleBase>();
                foreach (VisibleBase child in _children)
                {
                    child.gameObject.SetActive(true);
                }
            }
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
            if (_graphicRaycaster) _graphicRaycaster.enabled = _visible;

            return;
            if (_visible && _parent != null)
                _parent.Show();
        }
    }
}