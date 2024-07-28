using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Attributes
    [Header("Attribute")]
    public int level;
    public int health;
    public int damage;
    public float speed;
    public int goldReward = 10;

    // References
    private Rigidbody2D rb;
    private Transform target;
    private int pathIndex = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the target is set
        if (target != null)
        {
            // Enemy has reached the target
            if (Vector2.Distance(target.position, transform.position) <= 0.1f)
            {
                // Move to the next target in the path
                pathIndex++;
                if (pathIndex < LevelManager.instance.path.Length)
                {
                    target = LevelManager.instance.path[pathIndex];
                }
                else
                {
                    // Destroy the enemy when it reaches the end of the path
                    LevelManager.instance.homeHealth--;
                    Destroy(gameObject);
                    if (LevelManager.instance.homeHealth <= 0) {
                        LevelManager.instance.GameOver();
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Move the enemy towards the target
            Vector2 dir = (target.position - transform.position).normalized;
            rb.velocity = dir * speed;
        }
    }

    public void Initialize(EnemyLevel enemyLevel)
    {
        // Initialize the enemy's level and stats
        level = enemyLevel.level;
        health = enemyLevel.health;
        damage = enemyLevel.damage;
        speed = enemyLevel.speed;
    }

    public void SetPath(Transform[] path)
    {
        if (path.Length > 0)
        {
            target = path[0];
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce the enemy's health by the damage amount
        health -= damage;
        if (health <= 0)
        {
            // Destroy the enemy when its health reaches 0
            WaveManager waveManager = FindObjectOfType<WaveManager>();
            if(waveManager != null){
                waveManager.EnemyDestroyed();
            }
            LevelManager.instance.AddGold(goldReward);
            Destroy(gameObject);
        }
    }
}