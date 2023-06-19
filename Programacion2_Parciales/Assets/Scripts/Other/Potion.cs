using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class Potion : MonoBehaviour
{
	[SerializeField] private float _healthPoints;
	[SerializeField] private GameObject _potionParticleSystem;
	[SerializeField] private float _particleTime;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(CO_TakePotion());
		}
	}

	private IEnumerator CO_TakePotion()
	{
		_potionParticleSystem.SetActive(true);
		EventManager.instance.playerHealthIncreased.Invoke(_healthPoints);
		yield return new WaitForSeconds(_particleTime);
		gameObject.SetActive(false);
	}
}
