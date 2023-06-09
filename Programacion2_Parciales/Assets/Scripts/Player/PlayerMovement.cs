using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Cameras;
using Game.Interfaces;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, Explotable
{
	[Header("Values")]
	[SerializeField] private float _movementSpeed = 5f;
	public bool canMove;

	[Header("Inputs")]
	[SerializeField] private int _atkButttonindex = 0;

	[Header("Animator")]
	Animator _animator;
	[SerializeField] private string _xAxisName = "xAxis";
	[SerializeField] private string _zAxisName = "zAxis";

	[Header("Camera")]
	[SerializeField] private ThirdPersonCameraController _cameraRef;

	private Rigidbody _rb;
	public float xAxis { get; private set; }
	public float zAxis { get; private set; }
	public float MovementSpeed 
	{ 
		get => _movementSpeed; 
		set => _movementSpeed = value; 
	}

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.constraints = RigidbodyConstraints.FreezeRotation;
		if (_animator == null) _animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		xAxis = Input.GetAxis("Horizontal");
		zAxis = Input.GetAxis("Vertical");

		_animator.SetFloat(_xAxisName, xAxis);
		_animator.SetFloat(_zAxisName, zAxis);
	}

	private void FixedUpdate()
	{
		if ((xAxis != 0 || zAxis != 0)&& canMove)
		{
			_cameraRef.CameraMovement(xAxis,zAxis,_rb);
			Movement(xAxis, zAxis);
		}
	}

	public void Movement(float xAxis, float zAxis)
	{
		Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
		_rb.MovePosition(transform.position += dir * _movementSpeed * Time.fixedDeltaTime);
	}

	public void Explode()
	{
		Debug.Log($"Player has to explode, not being damaged in this method. ");
	}
}

