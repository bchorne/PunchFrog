using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public GameObject enemy;
    public int count;

    public EnemyWave(GameObject enemy, int count)
    {
        this.enemy = enemy;
        this.count = count;
    }
}

public class SpawnHandler : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<EnemyWave> waves;
    public ObjectPool pool;

    public List<GameObject> spawns;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
        waves = new List<EnemyWave>();
    }

    void Start()
    {
        waves.Add(new EnemyWave(enemies[0], 10));
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn 1 of whatever is currently at the top of our wave list, decrement it by one, remove if count is empty
        if (waves.Count > 0)
        {
            if (waves[0].count > 0)
            {
                //Fetch the enemy from the pool
                GameObject tmp = pool.GetPooledObject();

                //Choose a spawn point
                GameObject spawn = spawns[Random.Range(0, spawns.Count)];

                //Reposition enemy to that spawn
                tmp.transform.position = spawn.transform.position;

                //Refill enemy hp
                tmp.GetComponent<Enemy>().curHealth = tmp.GetComponent<Enemy>().maxHealth;

                //Activate them
                tmp.SetActive(true);

                //Add the enemy to the GameManager list
                GetComponent<GameManager>().enemies.Add(tmp.GetComponent<Enemy>());

                //Decrement wave counter
                waves[0].count--;
            }
            
            //Remove if empty
            if (waves[0].count <= 0)
            {
                waves.RemoveAt(0);
            }
        }
    }
}