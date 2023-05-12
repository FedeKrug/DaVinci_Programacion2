using System.Collections;
using System.Collections.Generic;

using Game.SO;

using UnityEngine;

namespace Game.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager instance;

		public FloatSO playerHealth;
		public Transform playerTransform;
		[SerializeField] private float _maxPlayerHealth;
		#region Singleton
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
		#endregion

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
		private void Start()
		{
			playerHealth.value = _maxPlayerHealth;
		}
		//private void Update()
		//{
		//	EventManager.instance.updateHealthUIEvent.Invoke(_maxPlayerHealth, playerHealth.value);

		//}
		public void IncreaseHealthHandler(float healthBoost)
		{
			playerHealth.value += healthBoost;
			EventManager.instance.updateHealthUIEvent.Invoke(_maxPlayerHealth, playerHealth.value);
			Debug.Log("Player increased health");
		}
		public void TakeDamageHandler(float damage)
		{
			playerHealth.value -= damage;
			EventManager.instance.updateHealthUIEvent.Invoke(_maxPlayerHealth, playerHealth.value);
			Debug.Log("Player damaged");

		}


	}
}
