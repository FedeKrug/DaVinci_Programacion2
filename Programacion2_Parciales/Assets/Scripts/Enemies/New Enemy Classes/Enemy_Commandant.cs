using System.Collections;
using System.Collections.Generic;

using Game.Interfaces;
using UnityEngine;

namespace Game.Enemies
{
	public class Enemy_Commandant : Enemy
	{
		[SerializeField] private bool _enemyWaveDead;





		public override void Death()
		{
			base.Death();
		}

		protected override void Attack()
		{
			
		}

		protected override bool attackCondition()
		{
			return true;
		}

		protected override void Move()
		{
			
		}

		protected override bool moveCondition()
		{
			if (_enemyWaveDead)
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
