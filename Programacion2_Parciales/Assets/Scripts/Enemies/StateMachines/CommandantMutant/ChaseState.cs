
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class ChaseState : State
	{
		
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField] private IdleState _idleState;
		[SerializeField] private MeleeAttackState _meleeAttackState;
		[SerializeField] private DistantAttackState _distantAttackState;
		public override State RunCurrentState()
		{
			if (_enemyRef.DistantAttackCondition())
			{
				return _distantAttackState;

			}
			else if (_enemyRef.MeleeAttackCondition())
			{
				return _meleeAttackState;
			}
			else if (!_enemyRef.DistantAttackCondition()&& !_enemyRef.MeleeAttackCondition())
			{
				return _idleState;
			}
			else
			{
				return this;
			}
		}
	}
}
