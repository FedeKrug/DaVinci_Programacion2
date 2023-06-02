using Game.Managers;
using Game.Enemies;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
	[SerializeField] protected float damage;
	protected bool playerDamaged, enemyDamaged;
	public abstract void UseBehaviour();
	protected virtual void MakeDamageToPlayer()
	{
		EventManager.instance.playerDamaged.Invoke(damage);
	}
}