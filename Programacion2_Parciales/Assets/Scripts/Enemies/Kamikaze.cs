
using UnityEngine;
namespace Game.Enemies
{
    public class Kamikaze: Enemy
	{
		protected override void CheckDeath()
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
