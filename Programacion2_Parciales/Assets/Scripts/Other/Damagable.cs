using Game.Managers;

using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
	[SerializeField] protected float damage;
	protected bool playerDamaged, enemyDamaged;
	public abstract void UseBehaviour();
	protected void MakeDamage()
	{
		if (playerDamaged)
		{
			EventManager.instance.playerDamaged.Invoke(damage);
		}
		else if (enemyDamaged)
		{
			
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) playerDamaged = true;
		if (other.CompareTag("Enemy")) enemyDamaged = true;
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) playerDamaged = false;
		if (other.CompareTag("Enemy")) enemyDamaged = false;

	}
}