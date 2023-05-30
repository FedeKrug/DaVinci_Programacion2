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
		[SerializeField] protected float damage = 100f;


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
        private void Update()
        {
			_distance = (transform.position - _target.position).sqrMagnitude;

			if (canMove)
			{
				if (moveCondition())
				{
					Move();
					if (attackCondition())
					{
						Attack();
					}
				}
				else
				{
					_anim.SetBool("InChaseRange", false);
					_agent.velocity = Vector3.zero;
				}
			}
		}


		#region Functions()
		
		protected virtual bool moveCondition()
        {
			if(_distance <= Mathf.Pow(_rangeToChase, 2))
            {
				return true;
            } else
            {
				return false;
            }
        }
		protected abstract void Move();
		protected abstract bool attackCondition();
		protected abstract void Attack();
		public abstract void CheckDeath(float health);
        #endregion

        #region Animationevents
        public void stopMovement()
		{
			_agent.isStopped = true;
			_agent.speed = 0;
			_agent.velocity = Vector3.zero;
			canMove = false;
		}
		public void startMovement()
		{
			_agent.isStopped = false;
			_agent.speed = _speed;
			_anim.SetBool("InAttackRange", false);
			canMove = true;
		}

		public virtual void animationAttack()
        {
			Collider[] player = Physics.OverlapSphere(transform.position, 5f);
			foreach (Collider contact in player)
			{
				if (contact.CompareTag("Player"))
					EventManager.instance.playerDamaged.Invoke(damage);
			}
		}

			#endregion
		}

}

		/*protected void Update()
		{
			_distance = (transform.position - _target.position).sqrMagnitude;

			if (canMove)
			{
				if (_distance <= Mathf.Pow(_rangeToChase, 2))
				{
					_anim.SetBool("InChaseRange", true);
					goToTarget();

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

		public abstract void goToTarget();
		
	}
}

*/

//CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe daño. >>> Iria al final del update
//canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal. >>> Iria al final del Start