using UnityEngine;
using Game.Enemies;
namespace Game.Enemies.Mutant
{
	public class DistantAttackState : State
	{
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private MeleeAttackState _meleeAttackState;
		[SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;

		public override State RunCurrentState()
		{
			if (_enemyRef.DistantAttackCondition() && !_enemyRef.MeleeAttackCondition())
			{
				_enemyRef.LookAtPlayer();
				_enemyBulletSpawner.enabled = true;
				return this;
			}
			else if (_enemyRef.MeleeAttackCondition() && _enemyRef.DistantAttackCondition())
			{
				_enemyBulletSpawner.enabled = false;
				return _meleeAttackState;
			}
			else
			{
				_enemyBulletSpawner.enabled = false;
				return _chaseState;
			}
		}

		
	}
}