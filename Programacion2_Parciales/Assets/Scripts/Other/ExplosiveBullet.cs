using Game.Managers;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ExplosiveBullet : Damagable
{
	protected override void UseBehaviour()
	{
		//Explosion
		MakeDamage();
	}
}
public class NormalBullet : Damagable
{
	protected override void UseBehaviour()
	{
		MakeDamage();
	}
}
public class MeleeAttack : Damagable
{
	protected override void UseBehaviour()
	{
		MakeDamage();
	}
}

public abstract class Damagable : MonoBehaviour
{
	[SerializeField] protected float damage;
	protected bool playerDamaged, enemyDamaged;
	protected abstract void UseBehaviour();
	protected void MakeDamage()
	{
		if (playerDamaged)
		{
			EventManager.instance.playerDamaged.Invoke(damage);
		}
		else if (enemyDamaged)
		{

		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) playerDamaged = true;
		if (other.CompareTag("Enemy")) enemyDamaged = true;
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) playerDamaged = false;
		if (other.CompareTag("Enemy")) enemyDamaged = false;

	}
}