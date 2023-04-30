using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
    public class PlayerMovementByTransform : MonoBehaviour
	{
		[SerializeField, Range(0, 20)] private float _minSpeed, _maxSpeed;
		private float _speed;
		private float _xAxis, _zAxis;

		private void Awake()
		{
			_speed = _minSpeed;
		}


		private void Update()
		{
			_xAxis = Input.GetAxisRaw("Horizontal");
			_zAxis = Input.GetAxisRaw("Vertical");

			if (_xAxis != 0 || _zAxis != 0)
			{
				Move(_xAxis, _zAxis);
			}

			if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
			{
				_speed = _maxSpeed;
			}
			if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
			{
				_speed = _minSpeed;
			}
		}

		private void Move(float xAxis, float zAxis)
		{
			var dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
			transform.position += dir * _speed * Time.deltaTime;
		}
	}
}

