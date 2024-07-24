using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public int level;
    public int health = 10;
    public int damage;
    public float speed;

    Rigidbody2D rb;

    private Transform target;
    public int pathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        target = LevelManager.instance.path[pathIndex];
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.instance.path.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        target = LevelManager.instance.path[pathIndex];
        Vector2 dir = (target.position - transform.position).normalized;
        rb.velocity = dir * speed;
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
        if (collision.gameObject.activeSelf)
        {
            
        }
    }
}
