//Hold Upgrades, fill upgrade menu, apply upgrade effects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<BasicUpgrade> Upgrades;
    public UpgradeDisplay upgradeTop;
    public UpgradeDisplay upgradeBot;
    public GameObject menu;
    public Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void ChooseUpgrades()
    {
        //Randomize 2 values, select those from the Upgrade List and load them into the Upgrade Displays
        int index;
        int index2;

        do
        {
            index = Random.Range(0, Upgrades.Count);
            index2 = Random.Range(0, Upgrades.Count);
        } while (index == index2);

        upgradeTop.LoadUpgrade(Upgrades[index]);
        upgradeBot.LoadUpgrade(Upgrades[index2]);
    }

    public void OpenUpgradeMenu()
    {
        menu.SetActive(true);
        ChooseUpgrades();

        Time.timeScale = 0f;
    }

    public void ApplyUpgrade(UpgradeDisplay upgrade)
    {
        upgrade.upgrade.ApplySelf(player);
        menu.SetActive(false);

        Time.timeScale = 1f;
    }
}
