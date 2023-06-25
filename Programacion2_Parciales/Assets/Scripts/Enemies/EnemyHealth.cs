using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Game.Enemies;
public class EnemyHealth : MonoBehaviour, IDeathByLava
{
	[Header("Stats")]
	private float _health;
	[SerializeField] private float _maxHealth;

	[Header("Aesthetics")]
	[SerializeField] private Material _enemyMaterial;
	[SerializeField] private Animator _anim;

	[Header("References")]
	[SerializeField] private Enemy _enemyRef;
	[SerializeField] private NavMeshAgent _enemyNavmesh;
	[SerializeField, Tooltip("World Canvas enemy Health Bar")] private WorldCanvasEnemyHealthBar _enemyHealthBar;

	private void Start()
	{
		_health = _maxHealth;
	}

	public IEnumerator Die()
	{
		_enemyRef.isAlive = false;
		_enemyRef.canMove = false;
		_enemyNavmesh.enabled = false;
		_anim.Play("Death");
		yield return new WaitForSeconds(4);
		StopAllCoroutines();
		_enemyRef.gameObject.SetActive(false);
	}

	public void TakeDamage(float damageAmount)
	{
		_health -= damageAmount;
		StartCoroutine(CO_TintRed());
		CheckDeath();
		if (_enemyHealthBar != null)
		{
			_enemyHealthBar.UpdateEnemyHealthBar(_health, _maxHealth);
		}
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
		_enemyMaterial.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		_enemyMaterial.color = Color.white;
	}

	void IDeathByLava.Die()
	{
		
	}
}

