using UnityEngine;

public class MeleeAttack : Damagable
{
	
	public override void UseBehaviour()
	{
		MakeDamageToPlayer();
	}
}
