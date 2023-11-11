//Class for loading in Upgrade scriptable objects into a UI Display Object.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    public TextMeshProUGUI upgradeName, description;
    public Image icon;
    public BasicUpgrade upgrade;
    public UpgradeManager upMan;

    public void Awake()
    {
        upMan = FindObjectOfType<UpgradeManager>();
    }

    public void LoadUpgrade(BasicUpgrade upgrade)
    {
        this.upgrade = upgrade;
        
        upgradeName.text = upgrade.upgradeName;
        description.text = upgrade.description;
        icon.sprite = upgrade.icon;
    }

    public void HandleClick()
    {
        upMan.ApplyUpgrade(this);
    }
}
