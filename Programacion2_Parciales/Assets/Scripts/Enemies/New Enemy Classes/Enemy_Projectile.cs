using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class Enemy_Projectile : MonoBehaviour
{
    Transform _target;
    Rigidbody _rb;
    [SerializeField]float _speed = 10f;
    Vector3 dir;
    float timer = 1f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _target = PlayerManager.instance.playerTransform;
        dir = (_target.position - transform.position).normalized * _speed;
        _rb.AddForce(dir, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
