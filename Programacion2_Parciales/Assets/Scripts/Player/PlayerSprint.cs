using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
	[SerializeField] private PlayerMovement _playerMovementRef;
	[SerializeField] private float _sprintSpeed;
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
		}
		if (Input.GetKeyUp(_sprintKey))
		{
			_baseSpeed = _normalSpeed;
		}
	}


}