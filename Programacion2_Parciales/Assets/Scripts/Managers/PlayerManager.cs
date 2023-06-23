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
		[SerializeField] private PlayerMovement _playerRef;
		[SerializeField] private float _maxPlayerHealth;
		[SerializeField] private AudioClip[] _playerClips;
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
			_playerRef.animator.Play("Hit");
			CheckDeath();
		}

		private void CheckDeath()
		{
			if (playerHealth.value <=0)
			{
				Die();
			}
		}
		public void Die()
		{
			StartCoroutine(CO_PlayerDeath());
		}
		private IEnumerator CO_PlayerDeath()
		{
			yield return null;
			Debug.Log($"Player is dead... TODO: Crear la corroutine para la muerte del player");
		}

		public void PlaySoundOnAnimation(int soundIndex)
		{
			AudioSource source = _playerRef.GetComponent<AudioSource>();
			AudioClip clip = _playerClips[soundIndex];
			if (source.enabled == false) source.enabled = true;
			if (source.clip == clip) return;
			source.Stop();
			source.clip = clip;
			source.Play();
			
		}
	}
}
