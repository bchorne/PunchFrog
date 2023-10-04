using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Magnet Upgrade")]
public class MagnetUpgrade : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.magnetRadius += amount;
        player.UpdateMagnet();
    }
}
