using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    public List<GameObject> pooledBullets;
    public GameObject bulletToPool;
    public int amountToPool;

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = (GameObject)Instantiate(bulletToPool);
            bullet.SetActive(false);
            pooledBullets.Add(bullet);
            bullet.transform.SetParent(this.transform);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            // if pooled bullets are NOT active, return that object
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
