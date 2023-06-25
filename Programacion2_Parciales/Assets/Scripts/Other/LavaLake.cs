using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class LavaLake : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		//if (other.gameObject.GetComponent<EnemyHealth>())
		//{
		//	other.gameObject.GetComponent<EnemyHealth>().Die();
		//}
		//else if (other.gameObject.CompareTag("Player"))
		//{
		//	PlayerManager.instance.Die();
		//}
		if (other.gameObject.GetComponent<IDeathByLava>() != null)
		{
			other.gameObject.GetComponent<IDeathByLava>().Die();
		}

	}
}
public interface IDeathByLava
{
	public void Die();
}