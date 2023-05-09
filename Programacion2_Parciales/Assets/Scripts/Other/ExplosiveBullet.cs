using Game.Managers;

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
		_explosionRay = new Ray(transform.position, transform.forward);

		if (Physics.Raycast(_explosionRay, out _hit, _explosiveRange, _explosiveLayer))
		{
			_hit.collider.GetComponent<PlayerMovement>()?
		}

	}
}
