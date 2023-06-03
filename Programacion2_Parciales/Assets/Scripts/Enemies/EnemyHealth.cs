using UnityEngine;
using Game.Enemies;
public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private float _health;

	

	public void TakeDamage(float damageAmount)
	{
		_health -= damageAmount;
		CheckDeath();
		Debug.Log($"Enemy lost {damageAmount} points of health.");
	}
	private void CheckDeath()
	{
		if (_health <= 0)
		{
			Debug.Log($"Enemy {gameObject.name} is dead.");
			gameObject.GetComponent<Enemy>().Death();
		}

	}


}
