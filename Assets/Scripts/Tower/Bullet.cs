using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 5f;
    private int damage = 1;
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

        rb.velocity = direction * speed;
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        if (enemyInfo != null)
        {
            
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position == target.position)
        {
            Destroy(gameObject);
            enemyInfo.TakeDamage(damage);
        }
    }
}
