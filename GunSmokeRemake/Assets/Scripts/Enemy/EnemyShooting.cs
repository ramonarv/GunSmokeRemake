using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float timer;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bullet;

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
