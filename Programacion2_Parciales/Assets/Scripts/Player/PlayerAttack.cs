using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private Ray _attackRay;
	private RaycastHit _hit;
	[SerializeField] private PlayerMovement _playerMovement;
	public void OnAttack()
	{
		_playerMovement.canMove = false;
	}
	public void OnEndAttack()
	{
		_playerMovement.canMove = true;

	}

}