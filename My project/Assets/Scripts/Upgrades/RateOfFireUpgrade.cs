using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Fire Rate Upgrade")]
public class RateOfFireUpgrade : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.shotsPerSecond += amount;
        player.UpdateRateOfFire();
    }
}
