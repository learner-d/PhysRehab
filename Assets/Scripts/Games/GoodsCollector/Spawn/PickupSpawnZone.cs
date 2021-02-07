using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnZone : MonoBehaviour
{
    [SerializeField]
    private bool _renderInGame = false;

    [SerializeField]
    private bool _isActive = false;
    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    private readonly int _zCoord = -1;

    private bool _initialized = false;
    private Rect _zone = default;

    private readonly List<Vector3> _generatedCoords = new List<Vector3>();

    /// Colors
    [SerializeField]
    private Color _inactiveColor;
    [SerializeField]
    private Color _activeColor;

    /// Components
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        PreInitialize();
    }

    private void PreInitialize()
    {
        Vector2 centerPosition = transform.position;
        Vector2 scale = transform.lossyScale;
        Vector2 minCornerPosition = centerPosition - scale / 2;
        _zone = new Rect(minCornerPosition, scale);
        _initialized = true;
    }

    public void Initialize()
    {
        Clear();
    }

    /// <summary>
    /// TODO: add using of 'margin'
    /// </summary>
    /// <param name="margin"></param>
    /// <returns></returns>
    public Vector3 NextCoord(float margin)
    {
        float x = Random.Range(_zone.xMin, _zone.xMax);
        float y = Random.Range(_zone.yMin, _zone.yMax);
        Vector3 result = new Vector3(x, y, _zCoord);
        _generatedCoords.Add(result);

        return result;
    }

    public void Clear()
    {
        IsActive = false;
        _generatedCoords.Clear();
    }

    private ulong __framesCount = 0;
    public void Update()
    {
        if (__framesCount % 10 == 0) // "optimization"
        {
            _spriteRenderer.forceRenderingOff = !_renderInGame;
            _spriteRenderer.color = _isActive ? _activeColor : _inactiveColor;
        }
    }
}
