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
			var RandomEnemy = _enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)].gameObject;
			Instantiate(RandomEnemy, transform.position, transform.rotation);
			for (int i =0; i<_enemyToSpawn.Length; i++)
			{
				_enemyToSpawn[i].tag = "EnemySummoned";
			}
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
