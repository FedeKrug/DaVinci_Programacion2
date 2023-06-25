using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;

public class PlayerAnimationProxy : MonoBehaviour
{
	[SerializeField] private PlayerAttack _playerAttackRef;
	[SerializeField] private PlayerJump _playerJumpRef;
	[SerializeField] private PlayerModifiedJump _playerModifiedJump;

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

	public void OnFallingDown()
	{
		_playerModifiedJump.FallingDownAnimParameter();
	}
	public void OnEndJump()
	{
		_playerJumpRef.LandOnFloor();
		_playerModifiedJump.LandOnFloor();
	}
	public void CheckFloor(float distance)
	{
		_playerModifiedJump.CheckFloorDistance(distance);
	}
	public void PlaySound(int audioClipIndex)
	{
		PlayerManager.instance.PlaySoundOnAnimation(audioClipIndex);
	}
}
