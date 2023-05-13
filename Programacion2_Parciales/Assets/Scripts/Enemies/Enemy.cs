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
		[SerializeField] public float health;
		[SerializeField] protected float damage;


		[Header("Animator")]
		[SerializeField] protected Animator _anim;

		[Header("NavMesh")]
		[SerializeField] protected NavMeshAgent _agent;
		[SerializeField] protected float _speed = 5f;
		[SerializeField] protected float _rangeToChase = 5f;
		[SerializeField] protected float _rangeToAttack = 2f;


		protected Transform _target;
		protected bool canMove;
		protected float _distance;


		protected void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
			_target = PlayerManager.instance.playerTransform; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
			_agent.speed = _speed;
		}

		protected void Update()
		{
			_distance = (transform.position - _target.position).sqrMagnitude;

			if (_distance <= Mathf.Pow(_rangeToChase, 2))
			{
				_anim.SetBool("InChaseRange", true);
				_agent.SetDestination(_target.position);

				if (_distance <= Mathf.Pow(_rangeToAttack, 2))
				{
					_anim.SetTrigger("InAttackRange");
				}

			}
			else
			{
				_anim.Play("Idle");
			}
		}
		public abstract void CheckDeath(float health);
		protected abstract void onAttackrange();
		
	}
}



//CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe daño. >>> Iria al final del update
//canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal. >>> Iria al final del Start