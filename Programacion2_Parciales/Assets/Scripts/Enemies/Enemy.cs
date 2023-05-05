using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Game.Interfaces;
namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour, Damagable
	{
		[SerializeField] protected float health;
		[SerializeField] protected Animator anim;
		[SerializeField] protected float damage;


		public virtual void TakeDamage()
		{
			health -= 2; //TODO: Add a variable to takeDamage
			CheckDeath();
		}

		protected abstract void CheckDeath();

	}
	public class Kamikaze: Enemy
	{
		protected override void CheckDeath()
		{
			
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Plyer"))
			{
				TakeDamage();
			}
		}
		
	}
	public class MeleeCombatient : Enemy
	{
		protected override void CheckDeath()
		{

		}

	}
	public class DistantWarrior : Enemy
	{
		protected override void CheckDeath()
		{

		}

	}
}
