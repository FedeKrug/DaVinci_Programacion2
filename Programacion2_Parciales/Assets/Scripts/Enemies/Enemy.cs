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
		[SerializeField] protected float _speed = 5f;
		[SerializeField] protected float _range = 5f;

		protected Transform _target;
		protected bool canMove;
		protected float _distance;

		protected abstract void CheckDeath();

		protected void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
			_target = PlayerManager.instance.playerTransform; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
			_agent.speed = _speed;
			//canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal.
		}

		protected void Update()
		{
			_distance = (transform.position - _target.position).sqrMagnitude;

			if (_distance <= Mathf.Pow(_range,2))
			{
				_agent.SetDestination(_target.position);

			}
			//CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe daño.
		}

		private void lookAtTarget()
        {

        }
	}
}
