using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] int lifemax;
    LifeComponent lifecomponent;
    [SerializeField] Image lifefillui;


    protected virtual void Awake()
    {
        lifecomponent = new LifeComponent(lifemax);
        lifecomponent.Configure(Death, Refresh, KnockDown);
    }

    public void Hit (int damage)
    {
        if (lifecomponent.Hit(damage))
        {
            OnTakeDamage();
            AudioManager.instance.GruntSFX();
        }
        
    }
    void Death()
    {
        
        OnDeath();
    }

    void Refresh(float val)
    {
        lifefillui.fillAmount = val;
        OnRefresh(val);
        Debug.Log("refreshing");
    }

    void KnockDown()
    {
        OnKnock();
    }

    
    protected abstract void OnDeath();

    protected abstract void OnKnock();

    protected abstract void OnRefresh(float val);

    protected abstract void OnTakeDamage();

}
