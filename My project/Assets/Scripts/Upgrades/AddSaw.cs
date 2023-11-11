using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/AddSaw")]
public class AddSaw : BasicUpgrade
{
    public override void ApplySelf(Player player)
    {
        player.AddOrbital();
    }
}
