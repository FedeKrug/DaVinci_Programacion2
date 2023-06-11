using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemies;

public class EnemySpawnPoint : MonoBehaviour
{
	[SerializeField] private int _maxEnemyCant;
	[SerializeField] private Enemy[] _enemyToSpawn;
	[SerializeField] private float _spawnerCooldown;
	private float _currentEnemyCant;

	private void Start()
	{
		_currentEnemyCant = _maxEnemyCant;
		StartCoroutine(CO_SpawnEnemies());
	}

	IEnumerator CO_SpawnEnemies()
	{
		while (_currentEnemyCant > 0)
		{
			Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)].gameObject, transform.position, transform.rotation);
			yield return new WaitForSeconds(_spawnerCooldown);
			_currentEnemyCant--;
		}
		if (_currentEnemyCant <= 0)
		{
			Destroy(gameObject);
		}
		else
		{
			StartCoroutine(CO_SpawnEnemies());

		}
	}


}
