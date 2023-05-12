using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    private Transform _camTransform;
    private Vector3 _camFixedForward, _camFixedRight;

	private void Start()
	{
        _camTransform = Camera.main.transform;
	}
    public void CameraMovement(float xAxis, float zAxis)
	{
        _camFixedForward = _camTransform.forward;
        _camFixedForward.y = 0f;
        _camFixedRight = _camTransform.right;
        _camFixedRight.y = 0f;
        Rotate(_camFixedForward.normalized);

        var dir = (_camFixedRight * xAxis + _camFixedForward * zAxis).normalized;



	}
    private void Rotate(Vector3 dir)
	{
        transform.forward = dir;
	}
}