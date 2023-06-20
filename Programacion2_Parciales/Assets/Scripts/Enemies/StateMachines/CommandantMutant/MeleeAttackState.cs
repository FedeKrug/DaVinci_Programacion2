
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class MeleeAttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private DistantAttackState _distantAttackState;
		[SerializeField] private Enemy_Commandant _enemyRef;
		public override State RunCurrentState()
		{
			if (_enemyRef.MeleeAttackCondition())
			{
				_enemyRef.GetComponentInChildren<Animator>().SetBool("InAttackRange", true);
				Debug.Log("Melee State");
				return this;
			}
			else if (_enemyRef.DistantAttackCondition())
			{
				return _distantAttackState;
			}
			else 
			{
				return _chaseState;
			}
		}
	}
}