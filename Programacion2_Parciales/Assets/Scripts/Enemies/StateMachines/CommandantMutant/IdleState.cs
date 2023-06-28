using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

//using static UnityEngine.GraphicsBuffer;

namespace Game.Enemies.Mutant
{
	public class IdleState : State
	{
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField] private ChaseState _chaseState;

		public override State RunCurrentState()
{
			float distance = (transform.position - _enemyRef.Target.position).sqrMagnitude;
			if (_enemyRef.ChaseCondition()) 
			{
				return _chaseState;
			}
			else
			{
				_enemyRef.StopMoving();
				//Debug.Log("IdleState");
				return this;
			}
		}
	}
}