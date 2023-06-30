using System.Collections;
using System.Collections.Generic;

using Game.Enemies;
using Game.Managers;

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


	[SerializeField]private int _enemyCant;
	[SerializeField]private int _enemySummonedCant;
	[SerializeField] private int _maxEnemyCant, _maxEnemySummonedCant;
	[SerializeField] private Enemy_Commandant _mutant;
	[SerializeField] private AdditiveSceneLoader _additiveSceneLoader;

	private void Start()
	{
		_enemyCant = _maxEnemyCant;
		_enemySummonedCant = _maxEnemySummonedCant;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.V))
		{
			_enemyCant--;
			CheckEnemyCant();
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			_enemySummonedCant--;
			CheckSummonedEnemyCant();
		}
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
			CheckEnemyCant();
		}
		if (other.CompareTag("EnemySummoned"))
		{
			_enemySummonedCant--;
			CheckSummonedEnemyCant();
		}
	}

	[ContextMenu("CheckEnemyCant")]
	public void CheckEnemyCant()
	{
		if (_enemyCant <= 0)
		{
			_additiveSceneLoader.boxCollider.enabled = true;
			Debug.Log("Enemies Dead ");

		}

	}
	[ContextMenu("CheckSummonedEnemyCant")]
	public bool CheckSummonedEnemyCant()
	{
		if (_mutant == null)
		{
			_mutant = FindObjectOfType<Enemy_Commandant>();
		}
		if (_enemySummonedCant <= 0)
		{
			Debug.Log("Call The Boss");
			StartCoroutine(_mutant.CO_JumpToTheBattle());
			return true;
		}
		else
		{
			return false;
		}
	}
}
