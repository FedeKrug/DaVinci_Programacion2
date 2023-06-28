using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class EnemyMeleeAttack : MonoBehaviour
	{
		[SerializeField] private Enemy_Commandant _enemyRef;
		[SerializeField, Tooltip("Un parametro para golpear con un brazo u otro")] private string _fistIndexParameter;
		[SerializeField] private Animator _anim;
		[SerializeField] private float _cooldown;
		[SerializeField] private float _maxCooldown;

		private void Start()
		{
			_cooldown = _maxCooldown;
		}

		private void Update()
		{
			_cooldown -= Time.deltaTime;
			if (_cooldown <=0)
			{
				MeleeAttack();
				_cooldown = _maxCooldown;
			}
		}
		public void MeleeAttack()
		{
			int fistIndex = Random.Range(0, 2);
			_anim.SetBool("InAttackRange", true);
			_anim.SetInteger(_fistIndexParameter, fistIndex);
		}
	}
}