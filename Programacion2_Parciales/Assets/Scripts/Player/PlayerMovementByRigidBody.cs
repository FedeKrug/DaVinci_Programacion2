using System;

using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementByRigidBody : MonoBehaviour
    {
        [SerializeField] Rigidbody _rb;
        [SerializeField, Range(0, 200)] private float _minSpeed, _maxSpeed;
        private float _speed;
        private float _xAxis, _zAxis;

        [SerializeField] private KeyCode _sprintKey;


        private void Awake()
        {
            _speed = _minSpeed;
            _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }
        private void Update()
        {
            _xAxis = Input.GetAxisRaw("Horizontal");
            _zAxis = Input.GetAxisRaw("Vertical");


            if (Input.GetKeyDown(_sprintKey))
            {
                _speed = _maxSpeed;
            }
            if (Input.GetKeyUp(_sprintKey))
            {
                _speed = _minSpeed;
            }
        }
        private void FixedUpdate()
        {
            if (_xAxis != 0 || _zAxis != 0) MoveWithPhysics(_xAxis, _zAxis);
        }

        private void MoveWithPhysics(float xAxis, float zAxis)
        {
            var dir = transform.right * xAxis + transform.forward * zAxis;
            _rb.velocity += dir * _speed * Time.fixedDeltaTime;
        }
    }
}

