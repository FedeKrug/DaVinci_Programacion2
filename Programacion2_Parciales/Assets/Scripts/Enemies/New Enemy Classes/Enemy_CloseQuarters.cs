using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

namespace Game.Enemies
{
    public class Enemy_CloseQuarters : Enemy
    {
        protected override void Move()
        {
            _anim.SetBool("InChaseRange", true);
            _agent.SetDestination(_target.position);
        }

        protected override bool attackCondition()
        {
            if (_distance <= Mathf.Pow(_rangeToAttack, 2))
            {
                return true;
            }
            else
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
    }
}



/* protected override void Move()
 {
     _anim.SetBool("InChaseRange", true);
     _agent.SetDestination(_target.position);
 }
 protected override bool attackCondition()
 {
     if (_distance <= Mathf.Pow(_rangeToAttack, 2))
     {
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
 }*/