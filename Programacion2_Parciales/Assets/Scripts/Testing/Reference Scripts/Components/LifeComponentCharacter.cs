using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LifeComponentCharacter
{
	//int life = 0;
	//int life_max = 0;
	//Action callback_death;
	//Action<float> callback_refresh;

	//public LifeComponentCharacter(int life, int life_max)
	//{
	//	this.life = life;
	//	this.life_max = life_max;
	//}
	//public LifeComponentCharacter(int life_max)
	//{
	//	this.life = life_max;
	//	this.life_max = life_max;
	//}


	//public void Configure(Action _cbk_death, Action<float> _cbk_refresh)
	//{
	//	callback_death = _cbk_death;
	//	callback_refresh = _cbk_refresh;

	//	Refresh();
	//}

	//public bool Hit(int damage)
	//{
	//	life -= damage;
	//	AudioManager.instance.PlayerGruntsSFX();
	//	if (life <= 0)
	//	{
	//		life = 0;
	//		callback_death?.Invoke();
	//		Refresh();
	//		return false;

	//	}
	//	else if (life <= 25)
	//	{

	//		Refresh();
	//		return true;
	//	}
	//	else
	//	{
	//		Refresh();
	//		return true;
	//	}


	//}

	//public void Heal(int heal)
	//{
	//	life += heal;
	//	if (life > life_max)
	//	{
	//		life = life_max;
	//	}

	//	Refresh();
	//}

	//void Refresh()
	//{
	//	float amount = (float)life / (float)life_max;
	//	Debug.Log("prueba" + amount);
	//	callback_refresh.Invoke(amount);


	//}

}
