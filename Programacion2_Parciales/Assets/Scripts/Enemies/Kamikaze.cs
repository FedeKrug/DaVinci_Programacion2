
using UnityEngine;
namespace Game.Enemies
{
    public class Kamikaze: Enemy
	{
		protected override void CheckDeath()
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
