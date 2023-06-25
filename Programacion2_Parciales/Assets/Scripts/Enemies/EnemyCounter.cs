using System.Collections;
using System.Collections.Generic;

using Game.Enemies;

using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

	#region Singleton
	public static EnemyCounter instance;
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

	private int _enemyCant;
	private int _enemySummonedCant;
	[SerializeField] private int _maxEnemyCant, _maxEnemySummonedCant;


	private void Start()
	{
		_enemyCant = _maxEnemyCant;
		_enemySummonedCant = _maxEnemySummonedCant;
	}
	public int EnemyCant
	{
		get => _enemyCant;
	}
	public int EnemySummonedCant
	{
		get => _enemySummonedCant;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			_enemyCant--;
		}
		if (other.CompareTag("EnemySummoned"))
		{
			_enemySummonedCant--;
		}
	}

	public void CheckEnemyCant()
	{
		if (_enemyCant <= 0)
		{
			Debug.Log("Enemies Dead ");
		}

	}

	public bool CheckSummonedEnemyCant(Enemy_Commandant mutant)
	{
		if (_enemySummonedCant <= 0)
		{
			Debug.Log("Call The Boss");
			mutant.battleAvailable = true;
			return true;
		}
		else
		{
			return false;
		}
	}
}
