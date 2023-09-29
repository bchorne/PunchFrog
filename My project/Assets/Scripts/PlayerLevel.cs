//https://www.youtube.com/watch?v=QN_B0imrECI 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int level = 1;
    private int exp = 0;

    public ExpBar bar;

    int toNext
    {
        get { return level * 1000; }
    }

    public void AddXp(int xp)
    {
        exp += xp;
        CheckLevelUp();
        bar.UpdateExpBar(exp, toNext);
    }
    
    private void CheckLevelUp()
    {
        if (exp >= toNext)
        {
            exp -= toNext;
            level++;
        }
    }
}
