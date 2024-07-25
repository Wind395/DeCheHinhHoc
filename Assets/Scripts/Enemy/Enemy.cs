using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public int level;
    public int health;
    public int damage;
    public float speed;

    private Rigidbody2D rb;
    private Transform target;
    private int pathIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) <= 0.1f)
            {
                pathIndex++;
                if (pathIndex < LevelManager.instance.path.Length)
                {
                    target = LevelManager.instance.path[pathIndex];
                }
                else
                {
                    Destroy(gameObject); // Qu�i ??n ?i?m cu?i, h?y qu�i
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            rb.velocity = dir * speed;
        }
    }

    public void Initialize(EnemyLevel enemyLevel)
    {
        level = enemyLevel.level;
        health = enemyLevel.health;
        damage = enemyLevel.damage;
        speed = enemyLevel.speed;
    }

    public void SetPath(Transform[] path)
    {
        if (path.Length > 0)
        {
            target = path[0];  // ??t ?i?m b?t ??u c?a ???ng ?i
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // X? l� va ch?m v?i c�c ??i t??ng kh�c
    }
}