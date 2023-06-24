using Game.Managers;
using Game.SO;

using UnityEngine;

public class CameraArm : MonoBehaviour
{
	[Header("Camera")]
	[SerializeField] private Camera _myCam;
	[SerializeField, Range(-1, 1)] private int _cameraOrientationX, _cameraOrientationY;
	public BoolSO orientationX, orientationY;
	[SerializeField] private bool _invertedX, _invertedY;

	[Header("Values")]
	[SerializeField] private float _camDistance = 6f;
	[SerializeField] private float _hitOffset = .2f;
	[SerializeField] private float _minClamp, _maxClamp;
	[SerializeField] private FloatSO _mouseSensibility;
	[SerializeField] private LayerMask _camViewLayer;
	[Header("Player")]
	[SerializeField] private Transform _target;

	private float _mouseX, _mouseY;
	private Vector3 _camPos, _dir;

	private Ray _camRay;
	private RaycastHit _hit;
	private bool _isCamBlocked;


	private void Start()
	{
		GameManager.instance.BlockCursor();
		GameManager.instance.HideCursor();
		_invertedX = orientationX.value;
		_invertedY = orientationY.value;
	}

	private void FixedUpdate()
	{
		_camRay = new Ray(transform.position, _dir);

		_isCamBlocked = Physics.SphereCast(_camRay, .1f, out _hit, _camDistance, _camViewLayer);

	}

	public void FollowPlayer()
	{
		transform.position = _target.position;
		_mouseX += Input.GetAxisRaw("Mouse X") * _mouseSensibility.value * Time.deltaTime;
		_mouseY += Input.GetAxisRaw("Mouse Y") * _mouseSensibility.value * Time.deltaTime;
		if (_mouseX <= -360 || _mouseX >= 360)
		{
			_mouseX -= 360 * Mathf.Sign(_mouseX);
		}

		_mouseY = Mathf.Clamp(_mouseY, _minClamp, _maxClamp);
		CheckMouseXAxisOrientation();
		CheckMouseYAxisOrientation();
		transform.rotation = Quaternion.Euler(/*_cameraOrientationY * */_mouseY, /*_cameraOrientationX * */_mouseX, 0f);

		_dir = -transform.forward;

		if (_isCamBlocked)
		{
			_camPos = _hit.point - _dir * _hitOffset;
		}
		else
		{
			_camPos = transform.position + _dir * _camDistance;
		}

		_myCam.transform.position = _camPos;
		_myCam.transform.LookAt(transform.position);
	}

	private void CheckMouseYAxisOrientation()
	{
		
		if (_invertedY)
		{
			_cameraOrientationY = -1;
		}
		else 
		{
			_cameraOrientationY = 1;
		}
	}

	private void CheckMouseXAxisOrientation()
	{
		if (_invertedX)
		{
			_cameraOrientationX = -1;
		}
		else 
		{
			_cameraOrientationX = 1;
		}
	}

	public void SetMouseXAxisOrientation()
	{
		_invertedX = !_invertedX;
	}
	public void SetMouseYAxisOrientation()
	{
		_invertedY = !_invertedY;
	}
}
