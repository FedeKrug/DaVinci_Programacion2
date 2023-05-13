using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAgent : EnemyBase
{
    [SerializeField] NavMeshAgent nav;
    [SerializeField] [Range(1, 10)] public float mySpeed = 5f;

    private void Start()
    {
        nav.speed = mySpeed;
    }

    protected void MoveTo(Vector3 pos)
    {
        nav.destination = pos;
    }
    protected void Stop()
    {
        nav.isStopped = true;
    }
    protected void Resume()
    {
        nav.isStopped = false;
    }

    protected void RunFrom(Vector3 pos, int multiplier)
    {
        nav.destination = transform.position + ((transform.position - pos).normalized * multiplier);
    }

    public NavMeshAgent myNav()
    {
        return nav;
    }

    protected override void OnDeath(){}
    protected override void OnRefresh(float val) { }
    protected override void OnTakeDamage() { }

    protected override void OnKnock() { }
}
