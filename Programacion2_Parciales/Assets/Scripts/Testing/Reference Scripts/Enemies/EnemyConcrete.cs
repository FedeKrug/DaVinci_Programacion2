using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConcrete : EnemyAgent
{/*
    GameManager GC;
    Characterswap CharSwap;
    [Range(2, 50)] public float minDistanceToFollow;
    [Range(2, 5)] public float minDistanceToAttack = 5f;
    [SerializeField] Animator myAnimator;
    [SerializeField] GameObject myGameObject;
    
    protected override void Awake()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        base.Awake();
        CharSwap = FindObjectOfType<Characterswap>();
    }
 
    

    void Update()
    {
   

        if (Vector3.Distance(this.transform.position, CharSwap.ReturnPlayerTransform().position) > minDistanceToFollow)
        {
            myAnimator.SetBool("RunRange", false);
            myNav().isStopped = true;
        }
        else
        {
            myAnimator.SetBool("RunRange", true);
            myNav().isStopped = false;
            if (myGameObject.CompareTag("Runner"))
            {
                Runner();
            }
            else
            {
                Hunter();
            }
        
        }

       
    }


    protected override void OnDeath() 
    {
        Destroy(myGameObject);
        GC.KillCount++;
    }
    protected override void OnRefresh(float val) { }
    protected override void OnTakeDamage() {}

    protected override void OnKnock() 
    {
        myAnimator.Play("Death", 2);
        myNav().enabled = false;
    }

    #region EnemyAi
    private void Runner()
    {
        RunFrom(CharSwap.ReturnPlayerTransform().position, 30);
    }
    private void Hunter()
    {
        float playerDistance = Vector3.Distance(this.transform.position, CharSwap.ReturnPlayerTransform().position);
        

        if(playerDistance > minDistanceToAttack)
        {
            Resume();
            MoveTo(CharSwap.ReturnPlayerTransform().position);
        }
        else
        {
            myAnimator.SetBool("MeleeRange", true);
            myAnimator.Play("Attack", 1);
            Stop();
        }
        

        //if (playerDistance < minDistanceToAttack)
        //{
        //    
        //}
    }



    #endregion */

}
