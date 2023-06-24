using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NormalCameraState : State
{
	public bool cameraFocus;
	[SerializeField] private KeyCode _focusCameraButton;
	[SerializeField] private FocusedCameraState _focusedCameraState;
	[SerializeField] private CameraArm _cameraRef;
	
	private void Update()
	{
		if (Input.GetKeyDown(_focusCameraButton))
		{
			cameraFocus = !cameraFocus;
		}
	}
	public override State RunCurrentState()
	{
		if (cameraFocus)
		{
			return _focusedCameraState;
		}
		else
		{
			_cameraRef.FollowPlayer();
			return this;

		}
	}
}
