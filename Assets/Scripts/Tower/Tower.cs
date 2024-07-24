using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("Attribute")]
    public int level;
    public int damage = 1;
    public float atkSpeed;
    public float range;
    public float fireRate;
    private float fireCountDown = 0f;

    [Header("Other Components")]
    public GameObject Bullet;
    public LayerMask enemyMask;

    private Transform target;

    Collider2D[] findTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTargetShoot();
    }

    private void FindTargetShoot()
    {
        findTarget = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);

        foreach (Collider2D c in findTarget)
        {
            if (findTarget != null)
            {
                ShootCountDown();
            }
        }
    }

    private void ShootCountDown()
    {
        fireCountDown -= Time.deltaTime;
        if ( fireCountDown < 0f )
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bulletsGO = Instantiate(Bullet, transform.position, Quaternion.identity);
        Bullet bullets = bulletsGO.GetComponent<Bullet>();
        foreach (Collider2D c in findTarget)
        {
            if (bullets != null)
            {
                bullets.Seek(c.transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
