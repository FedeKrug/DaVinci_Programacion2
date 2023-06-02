using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Cameras
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private float _smoothSpeed;
		
		
		[Space(10)]
		[SerializeField] private Vector3 _sidePos, _sideRot;
		
		[Space(10)]
		[SerializeField] private Vector3 _backPos, _backRot;
		
		[Space(10)]
		[SerializeField] private Vector3 _combatPos, _combatRot;
		
		[Space(10)]
		[SerializeField] private Vector3 _focusedPos, _focusedRot;



		private Vector3 _offset;
		private Vector3 _offsetRot;
		public TypesOfCamera cameraType { get; set; }


		private void FixedUpdate()
		{
			Vector3 desiredPos = _target.position + _offset;
			Vector3 desiredRot = _target.eulerAngles + _offsetRot;

			Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed);
			Vector3 smoothRot = Vector3.Lerp(transform.eulerAngles, desiredRot, _smoothSpeed);

			transform.position = smoothPos;
			transform.eulerAngles = smoothRot;

			switch (cameraType)
			{
				case TypesOfCamera.Sideview:
					_offset = _sidePos;
					_offsetRot = _sideRot;
					break;
				case TypesOfCamera.Backwards:
					_offset = _backPos;
					_offsetRot = _backRot;
					break;
				case TypesOfCamera.Combat:
					_offset = _combatPos;
					_offsetRot = _combatRot;
					break;
				case TypesOfCamera.Focused:
					_offset = _focusedPos;
					_offsetRot = _focusedRot;
					break;
				default:
					break;
			}
		}
		public void FocusOnEntity()
		{
			var actualCamera = cameraType;
			
		}
	}


}
