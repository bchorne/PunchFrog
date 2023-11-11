//https://learn.unity.com/tutorial/introduction-to-object-pooling 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Preloads a given amount of a prefab into the scene, then sets them to be inactive. This creates them all up front,
//and avoids loading hitches in the middle of gameplay by shifting all the burden to the start of the scene.
public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            tmp.transform.SetParent(gameObject.transform, false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject() //Find an inactive object in our pre-set pool and return it.
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
