using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLake : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<EnemyHealth>())
		{
			other.GetComponent<EnemyHealth>().Die();
		}
		else if (other.CompareTag("Player"))
		{

		}
	}
}
