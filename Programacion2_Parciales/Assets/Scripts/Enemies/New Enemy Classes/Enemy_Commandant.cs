using System.Collections;
using System.Collections.Generic;

using Game.Interfaces;

using UnityEngine;

namespace Game.Enemies
{
	public class Enemy_Commandant : Enemy_CloseQuarters
	{
		[SerializeField] private bool _battleAvailable; //un bool para determinar si el boss (commandant) puede saltar a escena a pelear con el player
		[SerializeField] private int _enemyCant = 6;



		public override void Death()
		{
			base.Death();
		}

		protected override void Attack()
		{

		}

		protected override bool AttackCondition()
		{
			if (_distance <= Mathf.Pow(_rangeToAttack, _rangeToAttack))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected override void Move()
		{
			base.Move();
		}

		protected override bool MoveCondition()
		{
			if (ReduceEnemies())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool ReduceEnemies()
		{
			_enemyCant--;
			if (_enemyCant <= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("EnemySummoned")) //enemigo invocado
			{
				ReduceEnemies();
			}
		}
	}

}
