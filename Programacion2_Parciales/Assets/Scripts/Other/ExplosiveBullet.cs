using Game.Managers;
using Game.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

public class ExplosiveBullet : Damagable
{
	[SerializeField] private float _explosiveRange;
	[SerializeField] private LayerMask _explosiveLayer;
	private Ray _explosionRay;
	private RaycastHit _hit;
	public override void UseBehaviour()
	{
		Explode();
		MakeDamage();
	}
	private void Explode()
	{
		//_explosionRay = new Ray(transform.position, transform.forward);
		Collider[] explotables = Physics.OverlapSphere(transform.position, _explosiveRange);

		foreach (Collider expObject in explotables)
		{
			expObject.GetComponent<Explotable>()?.Explode();
		}
		//if (Physics.SphereCast(_explosionRay, _explosiveRange, out _hit, _explosiveRange))
		//{
		//	var explodedObject = _hit.collider.GetComponent<Explotable>();
		//	if (explodedObject != null)
		//	{
		//		explodedObject.Explode();
		//	}


		//}

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Floor"))
		{
			UseBehaviour();
		}
	}
}
