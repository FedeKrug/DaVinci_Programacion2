﻿
using UnityEngine;
namespace Game.Enemies
{
    public class Kamikaze: Enemy
	{
		public override void CheckDeath(float health)
		{
			
		}

        protected override void onAttackrange()
        {
            throw new System.NotImplementedException();
        }

        private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Plyer"))
			{
				
			}
		}
		
	}
}
