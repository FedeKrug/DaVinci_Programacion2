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
		public bool battleAvailable; //un bool para determinar si el boss (commandant) puede saltar a escena a pelear con el player

		[Header("Animations")]
		[SerializeField] private AnimationClip _roaringAnimation;
		


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
			if (_distance <= Mathf.Pow(distantAttackRange, 2) && _health.Health < _health.MaxHealth * 0.5f)
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
			//Se usan state machines para el movimiento (ChaseState)
		}
		public bool ChaseCondition()
		{
			if (_distance <= Mathf.Pow(RangeToChase, 2) && canMove)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		protected override bool moveCondition()
		{
			return battleAvailable;
		}

		

		public void LookAtPlayer()
		{
			transform.LookAt(_target.position);
		}
		public override void animationAttack()
		{
			base.animationAttack();
		}
		public void CommandantMove()
		{
			base.Move();
			
		}
		public IEnumerator CO_JumpToTheBattle()
		{
			_anim.Play(_roaringAnimation.name);
			battleAvailable = true;
			//_anim.StopPlayback();
			Debug.Log($"Enemy is Roaring");
			yield return new WaitForSeconds(10);
			canMove = true;
			CommandantMove();
			
		}
	}
}
