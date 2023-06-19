using Game.Managers;
using Game.SO;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _myCam;
    [SerializeField, Range(-1,1)] private int _cameraOrientation;

    [Header("Values")]
    [SerializeField] private float _camDistance = 6f;
    [SerializeField] private float _hitOffset= .2f; 
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
    }

    private void FixedUpdate()
    {
        _camRay = new Ray(transform.position, _dir);

        _isCamBlocked = Physics.SphereCast(_camRay, .1f, out _hit, _camDistance,_camViewLayer);

    }

    private void LateUpdate()
	{
		//FollowPlayer();
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

		transform.rotation = Quaternion.Euler(_cameraOrientation * _mouseY, _mouseX, 0f);

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
}
