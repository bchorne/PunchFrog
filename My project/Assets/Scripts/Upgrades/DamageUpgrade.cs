using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Damage Upgrade")]
public class DamageUpgrade : BasicUpgrade
{
    // Start is called before the first frame update
    public override void ApplySelf(Player player) 
    {
        player.dmgMulti += amount;
        player.UpdateDamage();
    }
}
