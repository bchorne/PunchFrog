using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public PlayerLevel level;
    public TextMeshProUGUI text;
    private string Prefix = "Level: ";

    // Update is called once per frame
    void Update()
    {
        text.text = Prefix + level.Level.ToString();
    }
}
