using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public float burnDuration; // Thời gian bỏng
    public int burnDamagePerSecond; // Sát thương mỗi giây của hiệu ứng bỏng

    // Phương thức ghi đè khi đạn va chạm với kẻ thù
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.ApplyBurnEffect(burnDamagePerSecond, burnDuration); // Áp dụng hiệu ứng bỏng
        }
    }
}
