using System;

using Game.Enemies;

using UnityEngine;
namespace Game.Managers
{
	public class EnemyManager : MonoBehaviour
	{
		public static EnemyManager instance;

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
			//EventManager.instance.makeDamageToEnemyEvent.AddListener(TakeDamageHandler);
		}


		private void OnDisable()
		{
			//EventManager.instance.makeDamageToEnemyEvent.RemoveListener(TakeDamageHandler);

		}
		//private void TakeDamageHandler(float damage, float healthAmount, Enemy enemy)
		//{
		//	healthAmount -= damage;
		//	Debug.Log($"Enemy health is {healthAmount}, and he recieved {damage} points of damage. .");
		//	enemy.CheckDeath(healthAmount);
		//}

	}
}
