using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMenu : MonoBehaviour
{
    [SerializeField]
    private bool _renderInGame = true;

    private Canvas _canvas;
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        _canvas.enabled = _renderInGame;
    }
}
