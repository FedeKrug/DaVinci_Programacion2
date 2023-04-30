
using UnityEngine;

namespace Game.Player
{
	public class BetterPlayerJump : MonoBehaviour
	{
		[SerializeField] private float _maxJumpHeight;
		[SerializeField] private Rigidbody _rb;
		[SerializeField] private float _jumpTime;
		[SerializeField] private bool _isJumping;
		[SerializeField] private float _jumpTimer;

		private void Update()
		{
			//if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
			//{
			//	_isJumping = true;
			//	_jumpTimer = 0;
			//}

			if (Input.GetKeyUp(KeyCode.Space))
			{
				_isJumping = false;
				_jumpTimer = 0;
			}

			if (Input.GetKeyDown(KeyCode.Space) && _isJumping)
			{
				_jumpTimer += Time.deltaTime;
				if (_jumpTimer >= _jumpTime)
				{
					Jump();
				}
			}

			if (Input.GetKeyDown(KeyCode.Space) && _isJumping)
			{
				Jump();
			}

		}


		private void Jump()
		{
			var jumpForce = _maxJumpHeight / _jumpTime * _jumpTimer;

			var jumpVelocity = new Vector3(0, jumpForce, 0);
			_rb.AddForce(jumpVelocity, ForceMode.Impulse);
			_isJumping = false;
			_jumpTimer = 0;
		}
	}
}

