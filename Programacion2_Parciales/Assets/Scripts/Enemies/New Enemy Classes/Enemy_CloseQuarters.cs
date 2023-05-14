using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_CloseQuarters : Enemy
    {
        public override void CheckDeath(float health)
        {
           
        }

        public override void GoToTarget()
        {
            _agent.SetDestination(_target.position);
        }
    }
}
