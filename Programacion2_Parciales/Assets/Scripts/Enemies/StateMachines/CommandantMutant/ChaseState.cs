
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class ChaseState : State
	{
		public bool inMeleeAttackRange;
		public bool inDistantAttackRange;
		[SerializeField] private MeleeAttackState _meleeAttackState;
		[SerializeField] private DistantAttackState _distantAttackState;
		public override State RunCurrentState()
		{
			return this;
		}
	}
}