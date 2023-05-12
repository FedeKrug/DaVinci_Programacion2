using System.Collections;
using System.Collections.Generic;

using Game.SO;

using UnityEngine;

namespace Game.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager instance;

		public Transform playerTransform;
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
			EventManager.instance.playerHealthIncreased.AddListener(IncreaseHealthHandler);
			EventManager.instance.playerDamaged.AddListener(TakeDamageHandler);
		}

		private void OnDisable()
		{
			EventManager.instance.playerHealthIncreased.RemoveListener(IncreaseHealthHandler);
			EventManager.instance.playerDamaged.RemoveListener(TakeDamageHandler);
		}

		public void IncreaseHealthHandler(float healthBoost)
		{
			_playerHealth.value += healthBoost;
			Debug.Log("Player increased health");
		}
		public void TakeDamageHandler(float damage)
		{
			_playerHealth.value -= damage;
			Debug.Log("Player damaged");

		}


	}
}
