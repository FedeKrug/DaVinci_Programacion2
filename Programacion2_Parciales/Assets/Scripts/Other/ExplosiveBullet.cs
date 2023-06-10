
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
	[SerializeField] private float _speed = 5;

	public void InizializeBullet(Transform target, float lifetime)
	{
		_rb = GetComponent<Rigidbody>();
		StartCoroutine(CO_BulletBehaviour(target,lifetime));

	}

	private IEnumerator CO_BulletBehaviour(Transform target, float lifetime)
	{
		Vector3 dir = Vector3.zero;
		float tick = 0f;
		while (tick <=1)
		{
			dir = (target.position - transform.position).normalized;
			_rb.MovePosition(transform.position += dir * _speed * Time.deltaTime);
			tick += Time.deltaTime/ lifetime;
			yield return null;
		}
		UseBehaviour();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Floor"))
		{
			UseBehaviour();
		}
	}
}
