//https://www.youtube.com/watch?v=QN_B0imrECI 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider xpBar;

    public void UpdateExpBar(int current, int target)
    {
        xpBar.maxValue = target;
        xpBar.value = current;
    }
}
