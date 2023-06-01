using UnityEngine;
/*protected void Update()
{
	_distance = (transform.position - _target.position).sqrMagnitude;

	if (canMove)
	{
		if (_distance <= Mathf.Pow(_rangeToChase, 2))
		{
			_anim.SetBool("InChaseRange", true);
			goToTarget();

			if (_distance <= Mathf.Pow(_rangeToAttack, 2))
			{
				_anim.SetTrigger("InAttackRange");
			}

		}
	}
	else
	{
		_anim.SetBool("InChaseRange", false);
	}
}
public abstract void CheckDeath(float health);
public void stopMovement()
{
	_agent.isStopped = true;
	canMove = false;
}

public void startMovement()
{
	_agent.isStopped = false;
	canMove = true;
}

public abstract void goToTarget();

}
}

*/

//CheckDeath(); //TODO: Llamar a esta funcion solo cuando el enemigo recibe daño. >>> Iria al final del update
//canMove = true; //una confirmacion para el movimiento del enemy. TODO: cuando sea false, setear la velocidad de navmesh a 0, y cuando es true, a su velocidad normal. >>> Iria al final del Start

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private float _health;
	
	public void TakeDamage(float damageAmount)
	{
		_health -= damageAmount;
		CheckDeath();
	}
	private void CheckDeath()
	{
		if (_health <=0)
		{
			Debug.Log($"Enemy {gameObject.name} is dead.");
		}

	}
}