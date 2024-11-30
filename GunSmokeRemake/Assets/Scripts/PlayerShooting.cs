using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoint;
    public float bulletForce = 20f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetBool("isShootingForward", true);
        }
        else
        {
            animator.SetBool("isShootingForward", false);
        }
    }

    void Shoot()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(firePoint[i].up * bulletForce, ForceMode2D.Impulse);
        }
        
    }

}
