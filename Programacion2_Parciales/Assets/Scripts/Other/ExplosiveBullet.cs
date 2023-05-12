using Game.Managers;
using Game.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveBullet : Damagable
{

	[SerializeField] private float _explosiveRange;
	[SerializeField] private LayerMask _explosiveLayer;
	[SerializeField] private float _explosionForce;

	//private Ray _explosionRay;
	//private RaycastHit _hit;
	private Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}
	public override void UseBehaviour()
	{
		Explode();
		
	}
	private void Explode()
	{
		//_explosionRay = new Ray(transform.position, transform.forward);
		Collider[] explotables = Physics.OverlapSphere(transform.position, _explosiveRange);

		foreach (Collider expObject in explotables)
		{
			if (expObject.GetComponent<Explotable>() != null)
			{
				expObject.GetComponent<Explotable>().Explode();
				if (expObject.CompareTag("Player"))
				{
					MakeDamage();
				}

			}
		}


	}
	protected override void MakeDamage()
	{
		EventManager.instance.playerDamaged.Invoke(damage);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Floor"))
		{
			UseBehaviour();
		}
	}
}
