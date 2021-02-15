using UnityEngine;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    [RequireComponent(typeof(Canvas))]
    [ExecuteInEditMode]
    public abstract class VisibleBase : MonoBehaviour
    {
        protected bool _isAlive = false;

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

            _isAlive = true;
        }


        protected virtual void OnDestroy()
        {
            _isAlive = false;
        }

        public virtual void Show()
        {
            if(_isAlive == false)
                Debug.LogError("object is destroyed!");

            _visible = true;
            UpdateVisibility();
        }

        public virtual void Hide()
        {
            if (_isAlive == false)
                Debug.LogError("object is destroyed!");

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
            if(_isAlive == false)
                return;

            _canvas.enabled = _visible;
            if (_graphicRaycaster) _graphicRaycaster.enabled = _visible;

            return;
            if (_visible && _parent != null)
                _parent.Show();
        }
    }
}