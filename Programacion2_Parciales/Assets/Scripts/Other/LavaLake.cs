using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class LavaLake : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<IDeathByLava>() != null)
		{
			other.gameObject.GetComponent<IDeathByLava>().DieByLava();
		}

	}
}
