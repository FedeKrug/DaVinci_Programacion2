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
		protected float _distance;
		protected bool canMove = true;


		protected void Start()
		{
			_agent = GetComponent<NavMeshAgent>();
			_target = PlayerManager.instance.playerTransform; //una referencia desde el playerManager para que incluso los prefabs sepan donde esta el player.
			_agent.speed = _speed;
		}

		protected void Update()
		{
			_distance = (transform.position - _target.position).sqrMagnitude;

			if (canMove)
			{
				if (_distance <= Mathf.Pow(_rangeToChase, 2))
				{
					_anim.SetBool("InChaseRange", true);
					GoToTarget();

					if (_distance <= Mathf.Pow(_rangeToAttack, 2))
					{
						_anim.SetTrigger("InAttackRange");
					}

				}
			}
			else
			{
				_anim.SetBool("InChaseRange", false);
			}
		}
		public abstract void CheckDeath(float health);
		public void stopMovement()
        {
			_agent.isStopped = true;
			canMove = false;
        }

		public void startMovement()
        {
			_agent.isStopped = false;
			canMove = true;
		}

		public abstract void GoToTarget();

		
	}
}



//CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe da�o. >>> Iria al final del update
//canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal. >>> Iria al final del Start