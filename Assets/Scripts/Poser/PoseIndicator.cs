using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PoseIndicator : MonoBehaviour
{
    [SerializeField] private Line2 _leftArmLine;
    [SerializeField] private float _leftArmLineLength = 1.5f;
    [SerializeField] private float _leftArmAngleDeg = 45;
    [SerializeField] private Line2 _rightArmLine;
    [SerializeField] private float _rightArmLineLength = 1.5f;
    [SerializeField] private float _rightArmAngleDeg = 45;
    [SerializeField] private Line2 _leftLegLine;
    [SerializeField] private float _leftLegLineLength = 1.5f;
    [SerializeField] private float _leftLegAngleDeg = 45;
    [SerializeField] private Line2 _rightLegLine;
    [SerializeField] private float _rightLegLineLength = 1.5f;
    [SerializeField] private float _rightLegAngleDeg = 45;

    private float _leftArmLineLengthOld;
    private float _leftArmAngleDegOld;
    private float _rightArmLineLengthOld;
    private float _rightArmAngleDegOld;
    private float _leftLegLineLengthOld;
    private float _leftLegAngleDegOld;
    private float _rightLegLineLengthOld;
    private float _rightLegAngleDegOld;

    private void Initialize()
    {
        if ((bool)(_leftArmLine?.Empty))
            _leftArmLine = new Line2(transform.Find("ArmLeft").GetComponent<LineRenderer>());
        if ((bool)(_rightArmLine?.Empty))
            _rightArmLine = new Line2(transform.Find("ArmRight").GetComponent<LineRenderer>(), flipX:true);
        if ((bool)(_leftLegLine?.Empty))
            _leftLegLine = new Line2(transform.Find("LegLeft").GetComponent<LineRenderer>(), flipY:true);
        if ((bool)(_rightLegLine?.Empty))
            _rightLegLine = new Line2(transform.Find("LegRight").GetComponent<LineRenderer>(), flipX: true, flipY: true);


        _leftArmAngleDegOld = _leftArmAngleDeg;
        _leftArmLineLengthOld = _leftArmLineLength;
        _rightArmAngleDegOld = _rightArmAngleDeg;
        _rightArmLineLengthOld = _rightArmLineLength;

        _leftLegAngleDegOld = _leftLegAngleDeg;
        _leftLegLineLengthOld = _leftLegLineLength;
        _rightLegAngleDegOld = _rightLegAngleDeg;
        _rightLegLineLengthOld = _rightLegLineLength;
    }

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (_leftArmAngleDeg != _leftArmAngleDegOld)
        {
            _leftArmLine.AngleDeg = _leftArmAngleDeg;
            _leftArmAngleDegOld = _leftArmAngleDeg;
        }
        if (_leftArmLineLength != _leftArmLineLengthOld)
        {
            _leftArmLine.Magnitude = _leftArmLineLength;
            _leftArmLineLengthOld = _leftArmLineLength; 
        }
        if (_rightArmAngleDeg != _rightArmAngleDegOld)
        {
            _rightArmLine.AngleDeg = _rightArmAngleDeg;
            _rightArmAngleDegOld = _rightArmAngleDeg; 
        }
        if (_rightArmLineLength != _rightArmLineLengthOld)
        {
            _rightArmLine.Magnitude = _rightArmLineLength;
            _rightArmLineLengthOld = _rightArmLineLength; 
        }

        if (_leftLegAngleDeg != _leftLegAngleDegOld)
        {
            _leftLegLine.AngleDeg = _leftLegAngleDeg;
            _leftLegAngleDegOld = _leftLegAngleDeg;
        }
        if (_leftLegLineLength != _leftLegLineLengthOld)
        {
            _leftLegLine.Magnitude = _leftLegLineLength;
            _leftLegLineLengthOld = _leftLegLineLength;
        }
        if (_rightLegAngleDeg != _rightLegAngleDegOld)
        {
            _rightLegLine.AngleDeg = _rightLegAngleDeg;
            _rightLegAngleDegOld = _rightLegAngleDeg;
        }
        if (_rightLegLineLength != _rightLegLineLengthOld)
        {
            _rightLegLine.Magnitude = _rightLegLineLength;
            _rightLegLineLengthOld = _rightLegLineLength;
        }
    }
}