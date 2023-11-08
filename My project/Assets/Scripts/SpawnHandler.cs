using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public int count;
    public int poolIndex;

    public EnemyWave(int count, int poolIndex)
    {
        this.count = count;
        this.poolIndex = poolIndex;
    }
}

public class SpawnHandler : MonoBehaviour
{
    public List<EnemyWave> waves;
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
        while (true)
        {
            Debug.Log("Spawned Wave");
            waves.Add(new EnemyWave(10, 0));
            waves.Add(new EnemyWave(5, 1));
            waves.Add(new EnemyWave(1, 2));

            yield return new WaitForSeconds(100f);
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
                    GameObject spawn = spawns[Random.Range(0, spawns.Count)];

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
