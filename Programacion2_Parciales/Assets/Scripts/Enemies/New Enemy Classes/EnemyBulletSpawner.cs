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



		private void Start()
		{
			_target = PlayerManager.instance.playerTransform;
			StartCoroutine(CO_SpawnBullets());
		}
		

		IEnumerator CO_SpawnBullets()
		{
			var projectileSpawnPoint = _projectileSpawners[Random.Range(0, _projectileSpawners.Length)];
			_instBullet = Instantiate(_bullet,  projectileSpawnPoint.position, transform.rotation);
			_instBullet.InizializeBullet(_target, _bulletLifetime);
			yield return new WaitForSeconds(_cooldown);
			StartCoroutine(CO_SpawnBullets());
		}
	}
}
