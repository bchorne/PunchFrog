using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base scriptable object class for every upgrade. Unique upgrades inherit from this and write differently to the ApplySelf func.
public abstract class BasicUpgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public float amount;
    public Sprite icon;
    public bool once; //If you can only get the upgrade once.
    public abstract void ApplySelf(Player player);
}
