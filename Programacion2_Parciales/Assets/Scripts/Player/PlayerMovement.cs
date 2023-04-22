using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Cameras;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float _movementSpeed = 5f;

    [Header("Inputs")]
    [SerializeField] int _atkButttonindex = 0;

    [Header("Animator")]
    Animator _animator;
    [SerializeField] string _xAxisName = "xAxis";
    [SerializeField] string _zAxisName = "zAxis";


    Rigidbody _rb;
    float _xAxis, _zAxis;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        if (_animator == null) _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        _animator.SetFloat(_xAxisName, _xAxis);
        _animator.SetFloat(_zAxisName, _zAxis);
    }

    private void FixedUpdate()
    {
        if (_xAxis != 0 || _zAxis != 0) Movement(_xAxis, _zAxis);
    }

    private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
        _rb.MovePosition(transform.position += dir * _movementSpeed * Time.fixedDeltaTime);
    }
}
