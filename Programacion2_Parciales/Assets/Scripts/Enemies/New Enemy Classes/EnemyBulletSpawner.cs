using Game.Managers;

using System.Collections;

using UnityEngine;

namespace Game.Enemies
{
	public class EnemyBulletSpawner : MonoBehaviour
	{
		[SerializeField] private float _bulletLifetime;
		[SerializeField] private float _cooldown;
		[SerializeField] private ExplosiveBullet _bullet;
		[SerializeField] private Transform[] _projectileSpawners;
		private ExplosiveBullet _instBullet;
		private Transform _target;

		public float Cooldown
		{
			get => _cooldown;
			set => _cooldown = value;
		}

		private void Start()
		{
			_target = PlayerManager.instance.playerTransform;
		}


		public IEnumerator CO_SpawnBullets()
		{
			var projectileSpawnPoint = _projectileSpawners[Random.Range(0, _projectileSpawners.Length)];
			_instBullet = Instantiate(_bullet, projectileSpawnPoint.position, transform.rotation);
			_instBullet.InizializeBullet(_target, _bulletLifetime);
			yield return new WaitForSeconds(_cooldown);
			StartCoroutine(CO_SpawnBullets());
		}

		public void ShootingWithTimer(float timerTime)
		{
			float savedTime = timerTime;
			timerTime -= Time.deltaTime;
			if (timerTime <= 0)
			{
				var projectileSpawnPoint = _projectileSpawners[Random.Range(0, _projectileSpawners.Length)];
				_instBullet = Instantiate(_bullet, projectileSpawnPoint.position, transform.rotation);
				_instBullet.InizializeBullet(_target, _bulletLifetime);
				timerTime = savedTime;
			}
			//ShootingWithTimer(savedTime);
		}
	}
}
