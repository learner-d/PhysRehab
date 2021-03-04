using System;
using System.Collections;
using System.Collections.Generic;
using LightBuzz.Vitruvius;
using UnityEngine;
using Joint = LightBuzz.Vitruvius.Joint;

namespace PhysRehab.Generic
{
    public class FlapGesture : MonoBehaviour
    {
        private SensorAdapter _adapter; //Kinect-сенсор

        private int _predicateIndex = 0;
        private readonly Func<Body, bool>[] _predicates = {
        //1
        (body) =>
        {
            if (body != null)
            {
                Joint wristLeft = body.Joints[JointType.WristLeft];
                Joint wristRight = body.Joints[JointType.WristRight];
                Joint neck = body.Joints[JointType.Neck];
                return wristLeft.WorldPosition.Y > neck.WorldPosition.Y &&
                       wristRight.WorldPosition.Y > neck.WorldPosition.Y;
            }
            return false;
        },
        //2
        (body) =>
        {
            if (body != null)
            {
                Joint wristLeft = body.Joints[JointType.WristLeft];
                Joint wristRight = body.Joints[JointType.WristRight];
                Joint waist = body.Joints[JointType.SpineMid];
                return wristLeft.WorldPosition.Y < waist.WorldPosition.Y &&
                       wristRight.WorldPosition.Y < waist.WorldPosition.Y;
            }
            return false;
        }
    };

        [SerializeField]
        private float _flapTimeout = 1;

        private float _flapTimer = 0;

        private void OnEnable()
        {
            _adapter = new SensorAdapter(SensorType.Kinect2);
        }

        private void OnDisable()
        {
            if (_adapter != null)
            {
                _adapter.Close();
                _adapter = null;
            }
        }

        private void Update()
        {
            _flapTimer += Time.deltaTime;
        }

        public bool IsRecognised()
        {
            Frame frame = _adapter?.UpdateFrame();
            Body body = frame?.GetClosestBody();
            
            if (body != null && _predicates[_predicateIndex++].Invoke(body) == true)
            {
                if (_predicateIndex == 1)
                    _flapTimer = 0;
                else if (_predicateIndex == _predicates.Length)
                {
                    Reset();
                    return true;
                }
            }
            else
            {
                if (_flapTimer > _flapTimeout)
                    Reset();
            }

            return false;
        }


        public void Reset()
        {
            _predicateIndex = 0;
            _flapTimer = 0;
        }
    } 
}
