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
public class CameraArm : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _myCam;


    [Header("Values")]
    [SerializeField] private float _camDistance = 6f;
    [SerializeField] private float _hitOffset= .2f;
    [SerializeField] private float _minClamp, _maxClamp;
    [SerializeField] private float _mouseSensitivity; 
    [Header("Player")]
    [SerializeField] private Transform _target;

    private float _mouseX, _mouseY;
    private Vector3 _camPos, _dir;

    private Ray _camRaycast;
    private RaycastHit _hit;
    private bool _isCamBlocked;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _camRaycast = new Ray(transform.position, _dir);

        _isCamBlocked = Physics.SphereCast(_camRaycast, 1f, out _hit, _camDistance);

    }

    private void LateUpdate()
    {
        transform.position = _target.position;
        _mouseX += Input.GetAxisRaw("Horizontal") * _mouseSensitivity * Time.deltaTime;
        _mouseY += Input.GetAxisRaw("Vertical") * _mouseSensitivity * Time.deltaTime;
        if (_mouseX <=-360 || _mouseX>=360)
        {
            _mouseX -= 360 * Mathf.Sign(_mouseX);
        }

        _mouseY = Mathf.Clamp(_mouseY, _minClamp, _maxClamp);

        transform.rotation = Quaternion.Euler(-_mouseY, _mouseX, 0f);

        _dir = -transform.forward;

        if (_isCamBlocked)
        {
            _camPos = _hit.point - _dir * _hitOffset;
        }
        else
        {
            _camPos = transform.position + _dir * _camDistance;
        }
        

    }

}

