using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float timer;
    public Transform shootingPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, Quaternion.identity);
    }
}
