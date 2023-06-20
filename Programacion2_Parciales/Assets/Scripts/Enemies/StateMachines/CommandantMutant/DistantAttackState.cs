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
			if (_enemyRef.DistantAttackCondition())
			{
				//Timer(_enemyBulletSpawner.Cooldown);
				//StartCoroutine(_enemyBulletSpawner.CO_SpawnBullets());
				_enemyBulletSpawner.ShootingWithTimer(_enemyBulletSpawner.Cooldown);
				return this;
			}
			else if (_enemyRef.MeleeAttackCondition())
			{
				return _meleeAttackState;
			}
			else
			{
				return _chaseState;
			}
		}

		//private void Timer(float timerTime)
		//{
		//	float savedTime = timerTime;
		//	timerTime -= Time.deltaTime;
		//	if (timerTime <= 0)
		//	{
		//		StartCoroutine(_enemyBulletSpawner.CO_SpawnBullets());
		//		timerTime = savedTime;
		//	}
		//	Debug.Log("Distant State");
		//}
		
	}
}