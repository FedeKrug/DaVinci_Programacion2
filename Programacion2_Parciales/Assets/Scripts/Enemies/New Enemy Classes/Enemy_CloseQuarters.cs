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

        protected override bool AttackCondition()
        {
            if (_distance <= Mathf.Pow(_rangeToAttack, _rangeToAttack))
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

		public override void Death()
		{
			base.Death();
		}
		//public override void CheckDeath(float health)
		//{
		//    throw new System.NotImplementedException();
		//}

		//public override void Death()
		//{
		//          Debug.Log($"Enemy Close Quarters is dead");
		//          gameObject.SetActive(false);
		//}
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