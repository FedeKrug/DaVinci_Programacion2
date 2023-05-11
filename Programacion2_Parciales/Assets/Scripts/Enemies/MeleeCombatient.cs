using UnityEngine;

namespace Game.Enemies
{
	public class MeleeCombatient : Enemy
	{
		[SerializeField] private string _deathAnimation;
		protected override void CheckDeath()
		{
		//	if (health <= 0)
		//	{
		//		//canMove = false;
		//		anim.Play(_deathAnimation);
		//	}
		}

        protected override void onAttackrange()
        {
            throw new System.NotImplementedException();
        }
    }
}
