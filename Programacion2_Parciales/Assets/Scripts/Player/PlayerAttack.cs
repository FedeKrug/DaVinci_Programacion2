using UnityEngine;
using Game.Enemies;
public class PlayerAttack : MonoBehaviour
{
	private Ray _attackRay;
	private RaycastHit _hit;
	[SerializeField] private float _attackRange;
	[SerializeField] private float _attackDamage;
	[SerializeField] private Transform _attackPosition;

	[SerializeField] private PlayerMovement _playerMovement;
	public void OnAttack(float damage)
	{
		Collider[] catchedStuff = Physics.OverlapSphere(_attackPosition.position, _attackRange);
		foreach (Collider catchedEnemy in catchedStuff)
		{
			var enemyCatched = catchedEnemy.GetComponent<EnemyHealth>();
			if (enemyCatched != null)
			{
				enemyCatched.TakeDamage(damage);
			}
		}


	}

	public void OnStartAttack()
	{
		_playerMovement.canMove = false;
	}
	public void OnEndAttack()
	{
		_playerMovement.canMove = true;
	}

}