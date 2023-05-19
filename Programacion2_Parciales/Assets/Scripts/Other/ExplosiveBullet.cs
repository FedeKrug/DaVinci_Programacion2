
using Game.Managers;
using Game.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveBullet : Explosive
{
	private Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}
	//public override void UseBehaviour()
	//{
	//	Explode();
	//}

	protected override void MakeDamageToPlayer()
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
