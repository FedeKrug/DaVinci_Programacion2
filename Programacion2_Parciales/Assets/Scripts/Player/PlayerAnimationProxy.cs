using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAnimationProxy : MonoBehaviour
{
	[SerializeField] private PlayerAttack _playerRef;

	public void OnEndAnimation()
	{
		_playerRef.OnEndAttack();
	}
	public void OnAnttack()
	{
		_playerRef.OnAttack();

	}
}
