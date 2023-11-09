using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EnemyWave
{
    public int count;
    public int poolIndex;
    public float delay; //Time to wait before loading on next wave
}

public class SpawnHandler : MonoBehaviour
{
    public List<EnemyWave> waves;
    public List<EnemyWave> plannedWaves;
    public List<ObjectPool> pools;

    public List<GameObject> spawns;

    private void Awake()
    {
        waves = new List<EnemyWave>();
    }

    void Start()
    {
        StartCoroutine(addSpawn());
    }

    IEnumerator addSpawn()
    {
        while (plannedWaves.Count > 0)
        {
            waves.Add(plannedWaves[0]);

            float delay = plannedWaves[0].delay;

            plannedWaves.RemoveAt(0);

            yield return new WaitForSeconds(delay);
        }

        StartCoroutine("addRandomSpawn"); //Once out of planned waves, start spawning random ones.
    }

    IEnumerator addRandomSpawn()
    {
        while (true)
        {
            EnemyWave bas = new EnemyWave(), adv = new EnemyWave(), tnk = new EnemyWave(), mel = new EnemyWave();

            bas.count = UnityEngine.Random.Range(2, 15);
            adv.count = UnityEngine.Random.Range(0, 10);
            mel.count = UnityEngine.Random.Range(4, 15);
            tnk.count = UnityEngine.Random.Range(0, 3);

            bas.poolIndex = 0;
            adv.poolIndex = 1;
            tnk.poolIndex = 2;
            mel.poolIndex = 3;

            waves.Add(bas);
            waves.Add(adv);
            waves.Add(tnk);
            waves.Add(mel);

            yield return new WaitForSeconds(15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn 1 of whatever is currently at the top of our wave list, decrement it by one, remove if count is empty
        if (waves.Count > 0)
        {
            if (waves[0].count > 0)
            {
                //Attempt to fetch the enemy from the pool
                GameObject tmp = pools[waves[0].poolIndex].GetPooledObject();

                if (tmp != null) //Sanity check
                {
                    //Choose a spawn point
                    GameObject spawn = spawns[UnityEngine.Random.Range(0, spawns.Count)];

                    //Reposition enemy to that spawn
                    tmp.transform.position = spawn.transform.position;

                    //Refill enemy hp
                    tmp.GetComponent<Damageable>().currentHealth = tmp.GetComponent<Damageable>().maxHealth;

                    //Activate them
                    tmp.SetActive(true);

                    //Add the enemy to the GameManager list
                    GetComponent<GameManager>().enemies.Add(tmp.GetComponent<Enemy>());

                    //Decrement wave counter
                    waves[0].count--;
                }
            }
            
            //Remove if empty
            if (waves[0].count <= 0)
            {
                waves.RemoveAt(0);
            }
        }
    }
}
