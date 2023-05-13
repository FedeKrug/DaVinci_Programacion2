using UnityEngine;

namespace Game.Enemies
{
	public class MeleeCombatient : Enemy
	{
		[SerializeField] private string _deathAnimation;

		public override void CheckDeath(float health)
		{
			if (health <= 0)
			{
				Debug.Log("Melee Combatant is dead");
				//TODO: Animation of death
			}
		}
    }
}
