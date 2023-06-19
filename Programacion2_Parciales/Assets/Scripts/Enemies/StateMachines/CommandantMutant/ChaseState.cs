
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class ChaseState : State
	{
		public bool inMeleeAttackRange;
		public bool inDistantAttackRange;
		[SerializeField] private IdleState _idleState;
		[SerializeField] private MeleeAttackState _meleeAttackState;
		[SerializeField] private DistantAttackState _distantAttackState;
		public override State RunCurrentState()
		{
			if (inDistantAttackRange)
			{
				return _distantAttackState;

			}
			else if(inMeleeAttackRange)
			{
				return _meleeAttackState;
			}
			else
			{
				return this;
			}
		}
	}
}