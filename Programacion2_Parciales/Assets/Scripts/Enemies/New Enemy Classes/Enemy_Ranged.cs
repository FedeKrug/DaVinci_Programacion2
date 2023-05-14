using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Ranged : Enemy
    {
        public override void CheckDeath(float health)
        {
            throw new System.NotImplementedException();
        }

        public override void GoToTarget()
        {
            _agent.SetDestination(transform.position + ((transform.position - _target.position)).normalized);
        }
    }
}
