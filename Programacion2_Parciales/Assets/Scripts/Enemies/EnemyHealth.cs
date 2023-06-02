using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDeath
{
	[SerializeField] private float _health;

	public void Die()
	{
		
	}

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
			Die();
		}

	}


}
public interface IDeath
{
	public void Die() 
	{
		Debug.Log("Entity dead");
	}
	
}