using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FocusedCameraState : State
{
	[SerializeField] private NormalCameraState _normalCameraState;

	public override State RunCurrentState()
	{
		if (!_normalCameraState.cameraFocus)
		{
			return _normalCameraState;

		}
		else
		{
			Debug.Log("Focused Camera");
			return this;
		}
	}
}
