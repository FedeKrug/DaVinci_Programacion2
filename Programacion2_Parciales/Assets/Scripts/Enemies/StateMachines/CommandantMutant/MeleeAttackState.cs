
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class MeleeAttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		public override State RunCurrentState()
		{
			return this;
		}
	}
}