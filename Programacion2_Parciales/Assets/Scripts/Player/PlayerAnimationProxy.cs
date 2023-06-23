using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;

public class PlayerAnimationProxy : MonoBehaviour
{
	[SerializeField] private PlayerAttack _playerAttackRef;
	[SerializeField] private PlayerJump _playerJumpRef;

	#region Attack Methods
	public void OnStartAttack()
	{
		_playerAttackRef.OnStartAttack();
	}
	public void OnAnttack(float damage)
	{
		_playerAttackRef.OnAttack(damage);

	}
	public void OnEndAnimationAttack()
	{
		_playerAttackRef.OnEndAttack();
	}
	#endregion
	public void OnEndJump()
	{
		_playerJumpRef.LandOnFloor();
	}

	public void PlaySound(int audioClipIndex)
	{
		PlayerManager.instance.PlaySoundOnAnimation(audioClipIndex);
	}
}
