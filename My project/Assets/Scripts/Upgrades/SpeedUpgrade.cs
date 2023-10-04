using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Speed Upgrade")]
public class SpeedUpgrade : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.speed += amount;
        player.UpdateSpeed();
    }
}
