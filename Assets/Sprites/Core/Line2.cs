using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Line2
{
    [SerializeField]
    private LineRenderer _lr;
    [SerializeField]
    private bool _flipX = false;
    [SerializeField]
    private bool _flipY = false;
    public Vector3 Head
    {
        get => _lr.GetPosition(0);
        set => _lr.SetPosition(0, value);
    }
    public Vector3 Tail
    {
        get => _lr.GetPosition(1);
        set => _lr.SetPosition(1, value);
    }
    public bool Empty => _lr == null;
    public bool FlipX { get => _flipX ; set => _flipX = value; }
    public bool FlipY { get => _flipY ; set => _flipY = value; }

    public float AngleDeg
    {
        get
        {
            return Mathf.Acos((Tail - Head).y / Magnitude) * Mathf.Rad2Deg;
        }
        set
        {
            float tail_x = Head.x + Magnitude * Mathf.Sin(value * Mathf.Deg2Rad) * (_flipX ? -1 : 1);
            float tail_y = Head.y + Magnitude * Mathf.Cos(value * Mathf.Deg2Rad) * (_flipY ? -1 : 1);
            Tail = new Vector3(tail_x, tail_y, Head.z);
        }
    }

    public float Magnitude
    {
        get => Vector3.Distance(Tail, Head);
        set
        {
            float tail_x = Head.x + value * Mathf.Sin(AngleDeg * Mathf.Deg2Rad) * (_flipX ? -1 : 1);
            float tail_y = Head.y + value * Mathf.Cos(AngleDeg * Mathf.Deg2Rad) * (_flipY ? -1 : 1);
            Tail = new Vector3(tail_x, tail_y, Head.z);
        }
    }

    public Line2(LineRenderer lr, bool flipX = false, bool flipY = false)
    {
        if (lr.positionCount != 2)
            throw new System.ArgumentException("The input line renderer must have 2 vertices!");

        _lr = lr;
        _flipX = flipX;
        _flipY = flipY;
    }
}