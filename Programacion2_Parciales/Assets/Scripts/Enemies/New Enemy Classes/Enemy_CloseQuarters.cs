using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_CloseQuarters : Enemy
    {
        public override void CheckDeath(float health)
        {
            throw new System.NotImplementedException();
        }

        public override void goToTarget()
        {
            _agent.SetDestination(_target.position);
        }
    }
}
