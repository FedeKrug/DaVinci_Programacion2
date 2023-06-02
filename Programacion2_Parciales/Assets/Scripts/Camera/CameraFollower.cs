using System;

using UnityEngine;

namespace Game.Camera
{
	public class CameraFollower : MonoBehaviour
    {
        [Header("Target: ")]
        [SerializeField] private Transform _target;


        [Header("Values: ")]
        [SerializeField, Range(0, 10)] private float _smoothSpeed;
        private Vector3 _offset;



        private void Awake()
        {
            _offset = transform.position;
        }

        private void FixedUpdate()
        {
            Vector3 desiredPos = _target.position + _offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed);// values -> 0, 1, time to interpolate
            transform.position = smoothPos;
        }

    }

}

