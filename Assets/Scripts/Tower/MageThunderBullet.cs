using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet
{
    public float splashDamagePercentage; // Tỷ lệ % sát thương lan
    public int maxChainTargets = 2; // Số mục tiêu lan tối đa

    // Phương thức ghi đè khi đạn va chạm với kẻ thù
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy primaryTarget = collision.GetComponent<Enemy>();
        if (primaryTarget != null)
        {
            primaryTarget.ApplyChainLightning(damage, splashDamagePercentage, maxChainTargets); // Áp dụng sát thương lan
        }
    }
}
