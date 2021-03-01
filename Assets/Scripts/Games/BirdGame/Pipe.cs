using PhysRehab.UI.BirdGame;
using PhysRehab.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.BirdGame
{
    [ExecuteAlways]
    public class Pipe : MonoBehaviour
    {
        public static event UnityAction<Pipe> PipeCreated;
        public static event UnityAction<Pipe> PipeDestroyed;
        public static event UnityAction<Pipe, GameObject> PipeCollision;

        [SerializeField]
        private SpriteRenderer _headSprite;

        [SerializeField]
        private SpriteRenderer _bodySprite;

        [SerializeField]
        private bool _upsideDown = false;

        [SerializeField]
        private float _bodyHeight = 0;
        [SerializeField]
        private float _bodyWidth = 0;

        [SerializeField]
        private float _positionX = 0;
        [SerializeField]
        private float _positionY = 0;

        private bool _initialized = false;
        private void Awake()
        {
            if (_initialized == false)
            {
                if (_bodyHeight <= float.Epsilon)
                    _bodyHeight = _bodySprite.transform.localScale.y;
                if (_bodyWidth <= float.Epsilon)
                    _bodyWidth = _bodySprite.transform.localScale.y;

                if (_positionX <= float.Epsilon)
                    _positionX = transform.localPosition.x;

                if (_positionX <= float.Epsilon)
                    _positionY = transform.localPosition.y;

                PipeCreated?.Invoke(this);
                _initialized = true;
            }
        }

        private void Update()
        {
            if (Application.isEditor)
            {
                UpdateFlip();
                UpdateScale();
            }
        }

        private void OnDestroy()
        {
            PipeDestroyed?.Invoke(this);
        }
        private void UpdateFlip()
        {
            transform.rotation = _upsideDown?
                Quaternion.AngleAxis(180, Vector3.forward) :
                Quaternion.AngleAxis(0, Vector3.forward);
        }
        private void UpdatePosition()
        {
            transform.localPosition = new Vector3(_positionX, _positionY);
        }

        private void UpdateScale()
        {
            _bodySprite.transform.localScale = new Vector2(_bodyWidth, _bodyHeight);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Bird")
            {
                PipeCollision?.Invoke(this, collision.gameObject);
               
            }
        }
    } 
}
