using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAnimationProxy : MonoBehaviour
{
	[SerializeField] private PlayerAttack _playerAttackRef;
	[SerializeField] private PlayerJump _playerJumpRef;

	public void OnEndAnimationAttack()
	{
		_playerAttackRef.OnEndAttack();
	}
	public void OnAnttack()
	{
		_playerAttackRef.OnAttack();

	}
	public void OnEndJump()
	{
		_playerJumpRef.LandOnFloor();
	}
}
