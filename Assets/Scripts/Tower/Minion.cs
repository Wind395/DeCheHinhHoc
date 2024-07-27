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

    public bool foundEnemy;

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
            if (enemy != null)
            {
                target = enemy.transform;
                StartCoroutine(MoveAndAttack());
            }
        }
        if (findEnemies.Length == 0) {
            rb.velocity = Vector2.zero;
        }
    }


    IEnumerator MoveAndAttack() {

        float distance = Vector2.Distance(target.position, transform.position);
        if (distance <= 0.4)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            yield return null;
            Destroy(gameObject);
            
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
