
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class DistantAttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private MeleeAttackState _meleeAttackState;
		
		public override State RunCurrentState()
		{
			if (_chaseState.inDistantAttackRange)
			{

			return this;
			}
			else if(_chaseState.inMeleeAttackRange)
			{
				return _meleeAttackState;
			}
			else
			{
				return _chaseState;
			}
		}
	}
}