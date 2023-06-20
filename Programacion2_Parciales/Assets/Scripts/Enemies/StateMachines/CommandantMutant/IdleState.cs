using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class IdleState : State
	{
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField] private ChaseState _chaseState;

		public override State RunCurrentState()
		{
			if (_enemyRef.CheckEnemyCant())
			{
				return _chaseState;
			}
			else
			{
				return this;
			}
		}
	}
}