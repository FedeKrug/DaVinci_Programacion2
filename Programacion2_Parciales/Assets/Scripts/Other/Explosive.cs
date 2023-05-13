using Game.Interfaces;
using Game.Enemies;
using UnityEngine;
using Game.Managers;


public class Explosive : Damagable
{
	[SerializeField] protected float _explosiveRange;
	[SerializeField] protected LayerMask _explosiveLayer;
	[SerializeField] protected float _explosionForce;
	public override void UseBehaviour()
	{
		Explode();
	}
	protected void Explode()
	{
		Collider[] explotables = Physics.OverlapSphere(transform.position, _explosiveRange);

		foreach (Collider expObject in explotables)
		{
			if (expObject.GetComponent<Explotable>() != null)
			{
				expObject.GetComponent<Explotable>().Explode();
				if (expObject.CompareTag("Player"))
				{
					MakeDamageToPlayer();
				}
			}
			else if (expObject.GetComponent<Enemy>() != null)
			{
				var enemyHealth = expObject.GetComponent<Enemy>().health;
				var enemyCatched = expObject.GetComponent<Enemy>();
				EventManager.instance.makeDamageToEnemyEvent.Invoke(damage, enemyHealth,enemyCatched);
			}
		}
	}
}