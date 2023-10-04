using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Health Upgrade")]
public class HealthUpgrade : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.maxHealth += (int)amount;
        player.UpdateHealth();
    }
}
