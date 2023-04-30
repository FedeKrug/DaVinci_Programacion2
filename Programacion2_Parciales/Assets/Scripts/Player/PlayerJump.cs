
using System;

using UnityEngine;

namespace Game.Player
{
	public class PlayerJump : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private Rigidbody _rb;

		[SerializeField] private KeyCode _jumpKey;
		private void Update()
		{
			if (Input.GetKeyDown(_jumpKey))
			{
				Jump();
			}
		}

		private void Jump()
		{
			_rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
			//_rb.velocity = new Vector3(_rb.velocity.x, _jumpForce);
		}
	}
}

