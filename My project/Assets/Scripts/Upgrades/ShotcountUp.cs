using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/ShotUp")]
public class ShotcountUp : BasicUpgrade
{
    // Start is called before the first frame update
    public override void ApplySelf(Player player)
    {
        player.ShotAmountIncrease();
    }
}
