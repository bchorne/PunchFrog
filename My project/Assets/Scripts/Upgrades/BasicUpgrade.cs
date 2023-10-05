using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicUpgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public float amount;
    public Sprite icon;
    public abstract void ApplySelf(Player player);
}
