using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Game.Interfaces;
namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField] protected float health;
		[SerializeField] protected Animator anim;
		[SerializeField] protected float damage;


		

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
