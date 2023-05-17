using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public Weapons weaponType { get; set; }
    [SerializeField] private int _weaponIndex;
	[SerializeField] private Animator _anim;
	[SerializeField] private string _swordAnimation, _punchesAnimation;
	[SerializeField] private float _swordTime, _punchesTime;

	
	//En este script se cambian las armas con los input
	public void ChangeActualWeapon()
	{
		
		
		switch (weaponType)
		{
			case Weapons.Sword:
				StartCoroutine(WithdrawSword());
				break;
			case Weapons.Punch:
				StartCoroutine(SaveSword());
				break;
		}
	}
	public IEnumerator WithdrawSword ()
	{
		_anim.Play(_swordAnimation);
		yield return new WaitForSeconds(_swordTime);
	}
	public IEnumerator SaveSword()
	{
		_anim.Play(_punchesAnimation);
		yield return new WaitForSeconds(_punchesTime);
	}

}
