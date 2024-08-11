using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBullet : Bullet
{
    public float stunDuration; // Thời gian gây choáng
    public int stunThreshold; // Số lần bắn cần thiết để gây choáng
    private static int hitCount = 0; // Đếm số lần bắn

    // Phương thức ghi đè khi đạn va chạm với kẻ thù
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            hitCount++;
            if (hitCount >= stunThreshold)
            {
                enemy.TakeDamage(damage); // Gây sát thương cho kẻ thù
                enemy.ApplyStunEffect(stunDuration); // Áp dụng hiệu ứng gây choáng
                hitCount = 0; // Đặt lại đếm sau khi gây choáng
            }
            else
            {
                enemy.TakeDamage(damage); // Gây sát thương cho kẻ thù
            }
            Destroy(gameObject); // Hủy viên đạn sau khi va chạm
        }
    }
}