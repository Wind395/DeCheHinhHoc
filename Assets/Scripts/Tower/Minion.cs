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
    public float atkSpeed;
    public LayerMask enemyMask;
    public float maxHealth = 250f;
    public bool foundEnemy;

    public float currentHealth {get; private set;}
    [HideInInspector] public Enemy currentEnemy;
    private Transform target;
    Collider2D[] findEnemies;
    private bool canAtk = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        StartCoroutine(CheckAndHeal());
        StartCoroutine(Targeting());
    }

    // Update is called once per frame
    void Update()
    {
        atkSpeed -= Time.deltaTime;
        if(atkSpeed <= 0){
            canAtk = true;
        }
    }

    IEnumerator Targeting()
    {
        while (true)
        {
            FindTarget();
            yield return new WaitForSeconds(.5f);
        }
    }
    void FindTarget() {
        if(currentEnemy == null){
            Collider2D[] findEnemies = Physics2D.OverlapCircleAll(transform.position, atkRange, enemyMask);
            if(findEnemies.Length > 0){
                target = findEnemies[0].transform;
                StopCoroutine(MoveAndAttack());
                StartCoroutine(MoveAndAttack());
                Enemy enemy = target.GetComponent<Enemy>();
                if(enemy != null){
                    enemy.SetTargeted(true);
                }
            }
            else{
                if(target != null){
                    Enemy enemy = target.GetComponent<Enemy>();
                    if (enemy != null){
                        enemy.SetTargeted(false);
                    }
                }
                target = null;
                rb.velocity = Vector2.zero;
            }
        }
    }


    IEnumerator MoveAndAttack() {
        while(target != null && currentHealth > 0){
            float distance = Vector2.Distance(target.position, transform.position);
            if (distance <= 0.4f)
            {
                // Engage in combat
                rb.velocity = Vector2.zero;
                StartCoroutine(Combat());
                yield break;
            }
            else
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }yield return null;
        }
    }
    IEnumerator Combat(){
        Enemy enemy = target.GetComponent<Enemy>();
        currentEnemy = enemy;
        while(enemy != null && enemy.health > 0 && currentHealth > 0 && canAtk){
            enemy.TakeDamage(damage);
            canAtk = false;
            atkSpeed = 1;
            yield return new WaitForSeconds(1);
        }
        if(currentHealth <= 0){
            Die();
        }else if(enemy.health <= 0){
            currentEnemy = null;
            target = null;
            rb.velocity = Vector2.zero;
            enemy.SetTargeted(false);
            yield break;
        }
    }
    private IEnumerator CheckAndHeal()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            if (!foundEnemy)
            {
                currentHealth = Mathf.Min(maxHealth, currentHealth + maxHealth * 0.05f);
                Debug.Log("Minion heal: " + currentHealth);
            }
            yield return new WaitForSeconds(2f);
        }
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        if(currentHealth <= 0){
            Die();
        }
    }
    private void Die(){
        Destroy(gameObject);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
}
