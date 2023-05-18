using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Ranged : Enemy
    {
        [SerializeField] float _timer = 5f; 
        protected override void Move()
        {
            LookAtPlayer();
            _anim.SetBool("InChaseRange", true);
            _agent.SetDestination(transform.position + ((transform.position - _target.position).normalized) * _agent.speed);
            _timer -= Time.deltaTime;
        
        }
        protected override bool attackCondition()
        {
            if (_timer <= 0)
            {
                _timer = 5f;
                return true;
            } else
            {
                return false;
            }
        }
        protected override void Attack()
        {
            _anim.SetBool("InAttackRange", true);
        }
        public override void CheckDeath(float health)
        {
            throw new System.NotImplementedException();
        }

        private void LookAtPlayer()
        {
            Vector3 lookPos = _target.position - transform.position;
            lookPos.y = 0;
            transform.forward = lookPos;
        }

        public void spawnProjectile()
        {

        }
    }
}
