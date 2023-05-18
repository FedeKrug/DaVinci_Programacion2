using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
	public Weapons weaponType { get; set; }
	[Header("Weapon Types")]
	[SerializeField] private Weapons _newWeapon;
	[Header("Animations")]
	[SerializeField] private Animator _anim;
	[SerializeField] private string _swordAnimation, _punchesAnimation;
	[SerializeField] private float _swordTime, _punchesTime;

	[Header("Inputs & Weapons Features")]
	[SerializeField] private KeyCode _changeKey;
	[SerializeField, Tooltip("Weapons gameObject")] private List<GameObject> _weapons;
	[SerializeField] private bool _aimed;

	//En este script se cambian las armas con los input

	private void Update()
	{
		if (Input.GetKeyDown(_changeKey))
		{
			ChangeActualWeapon();
		}
	}
	public void ChangeActualWeapon()
	{
		_aimed = !_aimed; //armado o desarmado
		
		EventManager.instance.changeWeaponEvent.Invoke(_newWeapon);
		if (_aimed)
		{
			weaponType = Weapons.Sword;
		}
		else
		{
			weaponType = Weapons.Punch;

		}
		switch (weaponType)
		{
			case Weapons.Sword:
				StartCoroutine(WithdrawSword());
				break;
			case Weapons.Punch:
				StartCoroutine(HideWeapon());
				break;
		}
	}

	IEnumerator HideWeapon()
	{
		_anim.Play("SaveSword");
		yield return new WaitForSeconds(2.5f); //TODO: Add variables to these values
		_anim.Play(_punchesAnimation);
		yield return new WaitForSeconds(_punchesTime);
		for (int i = 0; i < _weapons.Count; i++)
		{
			_weapons[i].SetActive(false);
		}
	}


	public IEnumerator WithdrawSword()
	{
		_anim.Play(_swordAnimation);
		yield return new WaitForSeconds(_swordTime);
	}

}
