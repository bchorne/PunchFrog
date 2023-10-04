using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Exp Upgrade")]
public class ExpMultiUpgrade : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.expMultiplier += amount;
        player.UpdateLearning();
    }
}
