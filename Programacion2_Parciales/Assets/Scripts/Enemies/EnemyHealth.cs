﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Game.Enemies;
public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private float _health;
	[SerializeField] private Material _enemyMaterial;
	[SerializeField] private Animator _anim;
	[SerializeField] private Enemy _enemyRef;
	[SerializeField] private NavMeshAgent _enemyNavmesh;
	
	public IEnumerator Die()
	{
		_enemyRef.isAlive = false;
		_enemyRef.canMove = false;
		_enemyNavmesh.enabled = false;
		_anim.Play("Death");
		yield return new WaitForSeconds(4);
		_enemyRef.gameObject.SetActive(false);
	}

	public void TakeDamage(float damageAmount)
	{
		_health -= damageAmount;
		StartCoroutine(CO_TintRed());
		CheckDeath();
		
	}
	private void CheckDeath()
	{
		if (_health <= 0)
		{
			StartCoroutine(Die());
		}

	}
	IEnumerator CO_TintRed()
	{
		_enemyMaterial.color= Color.red;
		yield return new WaitForSeconds(0.2f);
		_enemyMaterial.color = Color.white;
	}
}

