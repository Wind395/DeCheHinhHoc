using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Minion : MonoBehaviour
{
    public float speed;
    public float atkRange;
    public int damage;
    public LayerMask enemyMask;

    private Transform target;
    Collider2D[] findEnemies;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }


    void FindTarget() {
        findEnemies = Physics2D.OverlapCircleAll(transform.position, atkRange, enemyMask);
        foreach (Collider2D enemy in findEnemies)
        {
            if (enemy != null) {
                target = enemy.transform;
                MoveAndAttack();
            }
        }
    }


    void MoveAndAttack() {
        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 0.4)
        {
            // Attack the enemy
            target.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); // Destroy minion after attack
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
}
