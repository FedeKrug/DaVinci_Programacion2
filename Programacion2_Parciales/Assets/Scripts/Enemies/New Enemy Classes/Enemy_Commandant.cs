using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using Game.Interfaces;

using UnityEngine;

namespace Game.Enemies
{
	public class Enemy_Commandant : Enemy_CloseQuarters
	{
		[Header("Enemies Spawner")]
		[SerializeField] public bool battleAvailable; //un bool para determinar si el boss (commandant) puede saltar a escena a pelear con el player
		[SerializeField] private int _enemyCant = 6;
		[SerializeField] private EnemyBulletSpawner _bulletSpawner;

		public override void Death()
		{
			base.Death();
			_bulletSpawner.enabled = false;
		}

		protected override void Attack()
		{
			base.Attack();
			battleAvailable = true;
			_bulletSpawner.enabled = true;
		}

		protected override bool attackCondition()
		{
			if (_distance <= Mathf.Pow(_rangeToAttack, 2))
			{
				battleAvailable = true;
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

		protected override bool moveCondition()
		{
			if (CheckEnemyCant() && base.moveCondition())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckEnemyCant()
		{
			//_enemyCant--;
			if (_enemyCant <= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
