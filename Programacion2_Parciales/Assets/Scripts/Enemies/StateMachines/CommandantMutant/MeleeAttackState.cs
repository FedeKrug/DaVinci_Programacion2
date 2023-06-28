using Game.Enemies;

using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class MeleeAttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private DistantAttackState _distantAttackState;
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField] private EnemyMeleeAttack _meleeRef;
		public override State RunCurrentState()
		{
			if (_enemyRef.MeleeAttackCondition())
			{
				_meleeRef.enabled = true;
				_enemyRef.LookAtPlayer();
				Debug.Log("Melee State");
				return this;
			}
			else if (_enemyRef.DistantAttackCondition())
			{
				_meleeRef.enabled = false;
				return _distantAttackState;
			}
			else 
			{
				_meleeRef.enabled = false;
				return _chaseState;
			}
		}
	}
}