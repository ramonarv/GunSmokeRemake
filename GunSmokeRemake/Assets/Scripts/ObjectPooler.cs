using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    public List<GameObject> pooledBullets;
    public List<GameObject> pooledDiagonalBullets;
    public GameObject bulletToPool;
    public GameObject diagonalBulletToPool;
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

        pooledDiagonalBullets = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = (GameObject)Instantiate(diagonalBulletToPool);
            bullet.SetActive(false);
            pooledDiagonalBullets.Add(bullet);
            bullet.transform.SetParent(this.transform);
        }
    }


    public GameObject GetBullet()
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

    public GameObject GetDiagonalBullet()
    {
        for (int i = 0; i < pooledDiagonalBullets.Count; i++)
        {
            // if pooled bullets are NOT active, return that object
            if (!pooledDiagonalBullets[i].activeInHierarchy)
            {
                return pooledDiagonalBullets[i];
            }
        }
        return null;
    }
}
