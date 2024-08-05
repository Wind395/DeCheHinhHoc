using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBowTower : BaseTower
{
    [Header("Attribute")]
    public int level;
    public float damage;
    public float atkSpeed;
    public float range;
    private float fireCountDown = 0f;
    [SerializeField] private float roatationSpeed = 200f;

    [Header("Other Components")]
    public GameObject Bullet;
    public LayerMask enemyMask;
    private Transform target;
    Collider2D[] findTarget;

    void Update()
    {
        if(target == null || !IsTargetInRange()){
            FindTarget();
        }else{
            RotateTowardTarget();
            ShootCountDown();
        }
    }

    private bool IsTargetInRange(){
        float distance = Vector2.Distance(transform.position, target.position);
        return distance <= range;
    }

    private void FindTarget()
    {
        findTarget = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);
        if (findTarget.Length > 0)
        {
            target = findTarget[0].transform;
        }
    }

    public override void SetStats(TowerScriptable tower)
    {
        base.SetStats(tower);
        level = base._level;
        damage = base._damage;
        atkSpeed = base._atkSpeed;
        range = base._range;
    }

    private void RotateTowardTarget()
    {
        float angel = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angel));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, roatationSpeed * Time.deltaTime);
    }

    private void ShootCountDown()
    {
        fireCountDown -= Time.deltaTime;
        if ( fireCountDown < 0f )
        {
            Shoot();
            fireCountDown = 1f / atkSpeed;
        }
    }

    private void Shoot()
    {
        if (target != null)
        {
            GameObject bulletsGO = Instantiate(Bullet, transform.position, Quaternion.identity);
            Bullet bullets = bulletsGO.GetComponent<Bullet>();
            if (bullets != null)
            {
                bullets.SetStatsBullet(damage);
                bullets.Seek(target);
            }
        }
    }


    public void ApplyCard(Card card)
    {
        switch (card.cardType)
        {
            case Card.CardTypes.ATK:
                damage *= card.damage;
                break;
            case Card.CardTypes.ATKSpeed:
                atkSpeed *= card.effect;
                break;
            case Card.CardTypes.Range:
                range *= card.effect;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Kiểm tra xem đối tượng va chạm có phải thẻ bài hay không
        if (other.gameObject.CompareTag("Card")) {
            if (other.gameObject.CompareTag("Card") == true) {
                Card card = other.gameObject.GetComponent<Draggable>().card;
                Debug.Log("Trigged");
                ApplyCard(card);
            } else {
                Debug.Log("Not Found");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
