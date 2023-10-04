using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicUpgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    //public image icon;
    public abstract void ApplySelf(Player player);
}
