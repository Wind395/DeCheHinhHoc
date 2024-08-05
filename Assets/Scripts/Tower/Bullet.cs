using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage;
    public float Speed;

    private Transform target;

    Vector2 direction;
    Rigidbody2D rb;
    Enemy enemyInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyInfo = target.GetComponent<Enemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //HitTarget();
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        direction = (target.position - transform.position).normalized;

        rb.velocity = direction * Speed;
    }

    public void SetStatsBullet(float damageValue)
    {
        damage = damageValue;
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position == target.position)
        {
            Destroy(gameObject);
            enemyInfo.TakeDamage(damage);
        }
    }
}
