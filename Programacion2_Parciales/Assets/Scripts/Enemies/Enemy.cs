using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;
using Game.Interfaces;
using UnityEngine.AI;
namespace Game.Enemies
{
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class Enemy : MonoBehaviour
	{
		[Header("Stats")]
		[SerializeField] protected float health;
		[SerializeField] protected float damage;

		[Header("Animator")]
		[SerializeField] protected Animator anim;

		[Header("NavMesh")]
		[SerializeField] protected NavMeshAgent _agent;
		protected Transform target;
		protected bool canMove;

		protected abstract void CheckDeath();

		protected void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
			target = PlayerManager.instance.playerTransform; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
			canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal.
		}

		protected void Update()
		{
			if (canMove)
			{
				_agent.SetDestination(target.position);

			}
			CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe daño.
		}

	}
}
