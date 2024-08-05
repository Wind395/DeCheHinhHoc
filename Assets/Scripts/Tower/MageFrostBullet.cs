using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet
{
    public float slowDuration; // Thời gian làm chậm
    public float slowPercentage; // Tỷ lệ % làm chậm

    // Phương thức ghi đè khi đạn va chạm với kẻ thù
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.ApplySlowEffect(slowPercentage, slowDuration); // Áp dụng hiệu ứng làm chậm
            }
    }
}
