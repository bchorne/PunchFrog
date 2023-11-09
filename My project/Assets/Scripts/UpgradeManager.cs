//Hold Upgrades, fill upgrade menu, apply upgrade effects

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<BasicUpgrade> Upgrades;
    public List<BasicUpgrade> MajorUpgrades;
    public UpgradeDisplay upgradeTop;
    public UpgradeDisplay upgradeBot;
    public GameObject menu;
    public TextMeshProUGUI upgradeText;
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

    public void ChooseMajorUpgrades()
    {
        int index;
        int index2;

        do
        {
            index = Random.Range(0, MajorUpgrades.Count);
            index2 = Random.Range(0, MajorUpgrades.Count);
        } while (index == index2);

        upgradeTop.LoadUpgrade(MajorUpgrades[index]);
        upgradeBot.LoadUpgrade(MajorUpgrades[index2]);
    }

    public void OpenUpgradeMenu()
    {
        menu.SetActive(true);

        if (player.level.Level % 3 == 2)
        {
            ChooseMajorUpgrades();
            upgradeText.text = "MAJOR UPGRADE!";
        }
        else
        {
            ChooseUpgrades();
            upgradeText.text = $"Next Major Upgrade In {2 - (player.level.Level % 3)} Levels"; 
        }

        Time.timeScale = 0f;
    }

    public void ApplyUpgrade(UpgradeDisplay upgrade)
    {
        upgrade.upgrade.ApplySelf(player);
        menu.SetActive(false);

        if (upgrade.upgrade.once) //If you can only pick it up once...
        {
            //Remove it from our upgrade list.
            MajorUpgrades.Remove(upgrade.upgrade);
        }

        Time.timeScale = 1f;
    }
}
