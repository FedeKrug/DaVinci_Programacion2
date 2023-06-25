using UnityEngine;
using Game.Managers;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeathByLava
{
	[Header("Animations")]
	[SerializeField] private Animator _anim;
	[SerializeField] private AnimationClip _deathByLavaAnimation;
	[SerializeField] private AnimationClip _deathAnimation;

	[Header("Particles")]
	[SerializeField] private GameObject _lavaParticleEffect;
	[SerializeField] private GameObject _deathParticles;
	[SerializeField] private float _particleTime;

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
		_anim.Play(_deathAnimation.ToString());
		yield return new WaitForSeconds(_particleTime);
		Revive();
		Debug.Log($"Player is dead... TODO: Crear la corroutine para la muerte del player");
	}
	public IEnumerator CO_PlayerDeathByLava()
	{
		_anim.Play(_deathByLavaAnimation.ToString());
		yield return new WaitForSeconds(_particleTime);
		Debug.Log($"Player is dead... TODO: Crear la corroutine para la muerte del player");
		Revive();
	}

	public void Revive()
	{
		//Colocar al player en un lugar seguro lejos de enemigos y la lava (Checkpoints?)
		Debug.Log($"Player Revived ... TODO: Colocar al player en un lugar seguro lejos de enemigos y la lava (Checkpoints?)");
	}
}