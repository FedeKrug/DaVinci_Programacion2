﻿using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
	[SerializeField] private PlayerMovement _playerMovementRef;
	[SerializeField] private float _sprintSpeed;
	[SerializeField] private string _sprintParameterAnim;
	[SerializeField] private bool _inSprint;
	private float _normalSpeed;
	private float _baseSpeed;
	[SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;

	private void Start()
	{
		_baseSpeed = _playerMovementRef.MovementSpeed;
		_normalSpeed = _playerMovementRef.MovementSpeed;
	}

	private void Update()
	{
		_playerMovementRef.MovementSpeed = _baseSpeed;
		if (Input.GetKey(_sprintKey))
		{
			_baseSpeed = _sprintSpeed;
			float newSpeed = _sprintSpeed / _normalSpeed;
			_playerMovementRef.animator.SetFloat(_sprintParameterAnim, (2));
		}
		if (Input.GetKeyUp(_sprintKey))
		{
			_baseSpeed = _normalSpeed;
			_playerMovementRef.animator.SetFloat(_sprintParameterAnim, 1);
		}
	}
}