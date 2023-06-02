using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.SO;
using System;

namespace Game.Managers
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager instance;

		[SerializeField] private FloatSO _SfxVolume;
		[SerializeField] private FloatSO _mouseSensibility;
		[SerializeField] private Image _healthBar;
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

		private void OnEnable()
		{
			EventManager.instance.updateHealthUIEvent.AddListener(UpdateHealthUIHandler);
		}

		private void OnDisable()
		{
			EventManager.instance.updateHealthUIEvent.RemoveListener(UpdateHealthUIHandler);
		}
		private void UpdateHealthUIHandler(float maxPlayerHealth, float playerHealth)
		{
			_healthBar.fillAmount = playerHealth / maxPlayerHealth;
		}



	}
}
