using UnityEngine;
using Game.Managers;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeathByLava
{
	public void DieByLava()
	{
		StartCoroutine(CO_PlayerDeathByLava());
		Debug.Log("Death by Lava AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
	}
	public void Die()
	{
		StartCoroutine(CO_PlayerDeath());
	}
	public IEnumerator CO_PlayerDeath()
	{
		yield return null;
		Debug.Log($"Player is dead... TODO: Crear la corroutine para la muerte del player");
	}
	public IEnumerator CO_PlayerDeathByLava()
	{
		yield return null;
		Debug.Log($"Player is dead... TODO: Crear la corroutine para la muerte del player");
	}
}