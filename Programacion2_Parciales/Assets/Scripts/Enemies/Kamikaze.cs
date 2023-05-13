
using UnityEngine;
namespace Game.Enemies
{
    public class Kamikaze: Enemy
	{
		public override void CheckDeath(float health)
		{
			
		}

        private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Plyer"))
			{
				
			}
		}
		
	}
}
