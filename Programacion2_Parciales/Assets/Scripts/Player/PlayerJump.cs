using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerJump : MonoBehaviour
{
	[Header("Values")]
	[SerializeField] private float _jumpForce;
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private KeyCode _jumpKey;
	[SerializeField] private bool _onFloor;

	[Space(10)]
	[Header("Animations")]
	[SerializeField] private string _animParameter;
	[SerializeField] private string _jumpParameter;
	[SerializeField] private Animator _anim;
	private void Update()
	{
		if (Input.GetKeyDown(_jumpKey) && _onFloor)
		{
			Jump();
		}
	}

	public void Jump()
	{
		_rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
		_anim.SetTrigger(_jumpParameter);
		_anim.SetBool(_animParameter, false);
		_onFloor = false;
	}
	public void LandOnFloor()
	{
		_anim.SetBool(_animParameter, true);
		_anim.ResetTrigger(_jumpParameter);
		_onFloor = true;
	}
}
