using Game.Interfaces;
using Game.Enemies;
using UnityEngine;
using Game.Managers;
using System.Collections;

public class Explosive : Damagable
{
	[SerializeField] protected float _explosiveRange;
	[SerializeField] protected float _explosionForce;
	[SerializeField] protected float _upForce;
	[SerializeField] protected GameObject _particleEffect;
	[SerializeField] protected float _particleTime;
	//TODO: Variable para tiempo de destruccion de ExplosiveBullet
	public override void UseBehaviour()
	{
		Explode();
		StartCoroutine(CO_ParticleExplosion());
	}
	protected void Explode()
	{
		Collider[] explotables = Physics.OverlapSphere(transform.position, _explosiveRange);

		foreach (Collider expObject in explotables)
		{
			Rigidbody rb = expObject.GetComponent<Rigidbody>();
			if (rb !=null && rb != this.GetComponent<Rigidbody>())
			{
				rb.AddExplosionForce(_explosionForce, transform.position, _explosiveRange,_upForce);
				if (expObject.GetComponent<Explotable>() != null)
				{
					expObject.GetComponent<Explotable>().Explode();
					if (expObject.CompareTag("Player"))
					{
						MakeDamageToPlayer();
					}
				}
				if (expObject.GetComponent<EnemyHealth>() != null)
				{
					expObject.GetComponent<EnemyHealth>().TakeDamage(damage);

				}
			}
		}
	}
	
	private IEnumerator CO_ParticleExplosion()
	{
		_particleEffect.SetActive(true);
		yield return new WaitForSeconds(_particleTime);
		Destroy(gameObject);
	}
}