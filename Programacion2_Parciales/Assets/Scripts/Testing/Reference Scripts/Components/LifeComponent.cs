using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LifeComponent
{
    GameManager GC;
    public int life = 0;
    int life_max = 0;
    Action callback_death;
    Action callback_knocked_down;
    Action<float> callback_refresh;
    UImanager GameOver;

    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public LifeComponent(int life, int life_max)
    {
        this.life = life;
        this.life_max = life_max;
    }
    public LifeComponent(int life_max)
    {
        this.life = life_max;
        this.life_max = life_max;
    }


    public void Configure(Action _cbk_death, Action<float> _cbk_refresh, Action _cbk_knck_down)
    {
        callback_death = _cbk_death;
        callback_refresh = _cbk_refresh;
        callback_knocked_down = _cbk_knck_down;
        Refresh();
    }

    public bool Hit(int damage)
    {

        life -= damage;

        if (life <= 0)
        {
            life = 0;
            callback_death?.Invoke();
            Refresh();
            return false;
            GC.KillCount++;
        }
        else if(life <= 25)
        {
            callback_knocked_down?.Invoke();
            Refresh();
            return true;
        }
        else
        {
            Refresh();
            return true;
        }

        
    }

    public void Heal(int heal)
    {
        life += heal;
        if(life > life_max)
        {
            life = life_max;
        }

        Refresh();
    }

    void Refresh()
    {
        float amount = (float) life / (float) life_max;
        Debug.Log("prueba" + amount);
        callback_refresh.Invoke(amount);


    }

}
