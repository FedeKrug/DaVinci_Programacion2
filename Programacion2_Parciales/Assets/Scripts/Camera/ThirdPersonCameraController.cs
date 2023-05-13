using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerRef;
    private Transform _camTransform;
    private Vector3 _camFixedForward, _camFixedRight;

	private void Start()
	{
        _camTransform = Camera.main.transform;
	}
    public void CameraMovement(float xAxis, float zAxis, Rigidbody rb)
	{
        _camFixedForward = _camTransform.forward;
        _camFixedForward.y = 0f;
        _camFixedRight = _camTransform.right;
        _camFixedRight.y = 0f;
        Rotate(_camFixedForward.normalized);

        Vector3 dir = (_camFixedRight * xAxis + _camFixedForward * zAxis).normalized;

        _playerRef.Movement(_playerRef.xAxis, _playerRef.zAxis);

	}
    private void Rotate(Vector3 dir)
	{
        _playerRef.transform.forward = dir;
	}
}
