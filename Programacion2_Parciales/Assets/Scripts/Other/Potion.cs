using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class Potion : MonoBehaviour
{
	[SerializeField] private float _healthPoints;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			EventManager.instance.playerHealthIncreased.Invoke(_healthPoints);
		}
	}
}
