using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;

public class Enemy_Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] float damage = 5f;


    Transform _target;
    Rigidbody _rb;
    Vector3 dir;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _target = PlayerManager.instance.playerTransform;
        dir = (_target.position - transform.position).normalized * _speed;
        _rb.AddForce(dir, ForceMode.Impulse);
        StartCoroutine(Lifetime());
    }


    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerAttack ply = other.gameObject.GetComponent<PlayerAttack>();
        if (ply != null)
        {
            EventManager.instance.playerDamaged.Invoke(damage);
            Destroy(this.gameObject);
        }
    }
}
