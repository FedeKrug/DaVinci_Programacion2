using System.Collections;
using System.Collections.Generic;

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
        [SerializeField] protected Transform _target;
         
        protected abstract void CheckDeath();

        protected void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        protected void Update()
        {
            _agent.SetDestination(_target.position);
        }

    }
}
