using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using Game.Interfaces;

using UnityEngine;

namespace Game.Enemies
{
	public class Enemy_Commandant : Enemy_CloseQuarters
	{
		[Header("Enemy Stats:")]
		[SerializeField] private EnemyHealth _health;
		public float distantAttackRange = 15f;
		public float meleeAttackRange;

		[Header("Enemies Spawner")]
		[SerializeField] public bool battleAvailable; //un bool para determinar si el boss (commandant) puede saltar a escena a pelear con el player
		[SerializeField] public int enemyCant = 6;

		protected override void Start()
		{
			base.Start();
			meleeAttackRange = _attkRange;
		}
		public override void Death()
		{
			base.Death();
		}

		protected override void Attack()
		{
			//Manejado por StateMachines
		}

		protected override bool attackCondition()
		{
			if (_distance <= Mathf.Pow(_rangeToAttack, 2))
			{

				return true;
			}
			else
			{
				return false;
			}
		}
		public bool DistantAttackCondition()
		{
			if (_distance <= Mathf.Pow(distantAttackRange, 2))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool MeleeAttackCondition()
		{
			return attackCondition();
		}
		protected override void Move()
		{
			base.Move();
		}

		protected override bool moveCondition()
		{
			//if (CheckEnemyCant() && base.moveCondition())
			//{
			//	return true;
			//}
			//else
			//{
			//	return false;
			//}
			return CheckEnemyCant();
		}

		public bool CheckEnemyCant()
		{
			if (enemyCant <= 0)
			{
				StartCoroutine(CO_JumpToTheBattle());
				battleAvailable = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		IEnumerator CO_JumpToTheBattle()
		{
			//TODO: Feedback de battleAvailable, por ejemplo que el Mutant haga una animacion de salto desde su podio. Hacerlo con una coroutine
			yield return null;
			battleAvailable = true;
		}
	}
}
