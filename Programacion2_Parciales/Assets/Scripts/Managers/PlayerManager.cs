using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager instance;
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		public FloatSO _playerHealth;


		private void OnEnable()
		{
			EventManager.instance.playerHealthIncreased.AddListener(IncreaseHealth);
			EventManager.instance.playerDamaged.AddListener(TakeDamage);
		}

		private void OnDisable()
		{
			EventManager.instance.playerHealthIncreased.RemoveListener(IncreaseHealth);
			EventManager.instance.playerDamaged.RemoveListener(TakeDamage);
		}

		public void IncreaseHealth(float healthBoost)
		{
			_playerHealth.value += healthBoost;
			Debug.Log("Player increased health");
		}
		public void TakeDamage(float damage)
		{
			_playerHealth.value -= damage;
			Debug.Log("Player damaged");

		}


	}
}
