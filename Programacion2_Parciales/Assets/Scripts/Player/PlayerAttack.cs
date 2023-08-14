using UnityEngine;
using Game.Enemies;
using Game.Managers;
public class PlayerAttack : MonoBehaviour
{
	private Ray _attackRay;
	private RaycastHit _hit;
	[SerializeField] private float _attackRange = 3;
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
				PlayerManager.instance.PlaySoundOnAnimation(4); //stabbingEnemies Sound
			}
			else
			{
				PlayerManager.instance.PlaySoundOnAnimation(6);

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
