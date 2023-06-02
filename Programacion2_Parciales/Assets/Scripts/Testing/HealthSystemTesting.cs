using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;
public class HealthSystemTesting : MonoBehaviour
{
	[SerializeField, Range(0,100)] private float _damage, _healthBoost;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			//PlayerManager.instance.IncreaseHealth(_healthBoost);
			//EventManager.instance.playerHealthIncreased.Invoke(_healthBoost);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			//PlayerManager.instance.TakeDamage(_damage);
			//EventManager.instance.playerDamaged.Invoke(_damage);
		}
	}
}
