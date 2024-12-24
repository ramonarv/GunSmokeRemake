using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemyShooting : MonoBehaviour
{
    private float timer;
    [SerializeField] Transform[] shootingPoint;
    [SerializeField] GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.5f)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootingPoint[0].position, shootingPoint[0].rotation);
        Instantiate(bullet, shootingPoint[1].position, shootingPoint[1].rotation);
        Instantiate(bullet, shootingPoint[2].position, shootingPoint[2].rotation);
    }
}
