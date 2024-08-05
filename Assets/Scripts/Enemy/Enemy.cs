using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Attributes
    [Header("Attribute")]
    public int level;
    public float health;
    public int damage;
    public float speed;
    public int goldReward = 10;

    // References
    private Rigidbody2D rb;
    private Transform target;
    private int pathIndex = 0;
    private bool isTargeted = false;
    public bool inCombat = false;


    // Burn effect attributes
    private bool isBurning = false;
    private float burnTimeRemaining = 0;
    private int burnDamagePerSecond;
    private Coroutine burnCoroutine;

    // Slow effect attributes
    private bool isSlowed = false;
    private float originalSpeed;
    private Coroutine slowCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the target is set
        if (target != null && !inCombat && ! isTargeted)
        {
            Move();
        }else{
            rb.velocity = Vector2.zero;
        }
    }
    void Move(){
        // Enemy has reached the target
        if(Vector2.Distance(target.position, transform.position) <= .1f){
            // Move to the next target in the path
            pathIndex ++;
            if(pathIndex < LevelManager.instance.path.Length){
                target = LevelManager.instance.path[pathIndex];
            }else{
                // Destroy the enemy when it reaches the end of the path
                LevelManager.instance.homeHealth--;
                Destroy(gameObject);
                if (LevelManager.instance.homeHealth <= 0) {
                    LevelManager.instance.GameOver();
                }
            }
        }
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
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
    public void SetTargeted(bool targeted){
        isTargeted = targeted;
    }
    public void TakeDamage(float damage)
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


    // Apply burn effect
    public void ApplyBurnEffect(int damagePerSecond, float duration)
    {
        burnDamagePerSecond = damagePerSecond;
        burnTimeRemaining = duration;
        if (!isBurning)
        {
            isBurning = true;
            burnCoroutine = StartCoroutine(Burn());
        }
        else
        {
            // Reset burn time if already burning
            burnTimeRemaining = duration;
        }
    }

    private IEnumerator Burn()
    {
        while (burnTimeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            TakeDamage(burnDamagePerSecond);
            burnTimeRemaining -= 1f;
        }
        isBurning = false;
    }

    // Apply slow effect
    public void ApplySlowEffect(float slowPercentage, float duration)
    {
        if (isSlowed)
        {
            // If already slowed, refresh the duration
            StopCoroutine(slowCoroutine);
        }
        else
        {
            // Apply slow effect
            isSlowed = true;
            speed *= (1f - slowPercentage / 100f);
        }
        slowCoroutine = StartCoroutine(Slow(duration));
    }

    private IEnumerator Slow(float duration)
    {
        yield return new WaitForSeconds(duration);
        // Reset speed after slow effect ends
        speed = originalSpeed;
        isSlowed = false;
    }


    public void ApplyChainLightning(float damage, float splashDamagePercentage, int maxChainTargets)
    {
        List<Enemy> enemiesInRange = new List<Enemy>();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f); // Vùng ảnh hưởng của sát thương lan

        foreach (Collider2D hit in hitEnemies)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null && enemy != this) // Tránh bắn trúng kẻ thù chính
            {
                enemiesInRange.Add(enemy);
            }
        }

        // Giới hạn số lượng mục tiêu lan
        int targetsToDamage = Mathf.Min(maxChainTargets, enemiesInRange.Count);

        for (int i = 0; i < targetsToDamage; i++)
        {
            Enemy targetEnemy = enemiesInRange[i];
            targetEnemy.TakeDamage((int)(damage * splashDamagePercentage / 100f));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Minion") && !inCombat && collision.GetComponent<Minion>().currentEnemy == null){
            StartCoroutine(Combat(collision.gameObject.GetComponent<Minion>()));
        }
    }
    IEnumerator Combat(Minion minion){
        inCombat = true;
        minion.currentEnemy = this;
        while(minion != null && minion.currentHealth > 0 && health > 0){
            minion.TakeDamage(damage);
            yield return new WaitForSeconds(1f);
        }
        if (health <= 0){
            minion.currentEnemy = null;
            Destroy(gameObject);
            yield break;
        }
        if(minion.currentHealth <= 0){
            inCombat = false;
            yield break;
        }
    }
}