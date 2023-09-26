using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Enemy> enemies;

    void Start()
    {
        //For now, just fetch all enemies in scene on start, refine later once waves are in.
        enemies.AddRange(FindObjectsOfType<Enemy>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
