using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooting : MonoBehaviour
{
    private float bulletForce = 20f;
    private Animator animator;

    public Transform forwardPoint1, forwardPoint2;
    public Transform leftPoint1, leftPoint2;
    public Transform rightPoint1, rightPoint2;

    Transform[] forwardFirepoints;
    Transform[] leftFirepoints;
    Transform[] rightFirepoints;


    // variables for input buffer
    private bool fire1Pressed = false;
    private bool fire2Pressed = false;
    private float fire1LastTime;
    private float fire2LastTime;
    private float fireBufferTime = 0.15f;
    private float clickTime;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        forwardFirepoints = new Transform[] { forwardPoint1, forwardPoint2 };
        leftFirepoints = new Transform[] { leftPoint1, leftPoint2 };
        rightFirepoints = new Transform[] { rightPoint1, rightPoint2 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire1Pressed = true;
            fire1LastTime = Time.time;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            fire2Pressed = true;
            fire2LastTime = Time.time;
        }
        
        // Buffer timers for more consistent input detection (especially for LMB + RMB)
        clickTime = Mathf.Abs(fire1LastTime - fire2LastTime);
        bool bufferOver = (clickTime >= fireBufferTime);


        if (fire1Pressed && fire2Pressed)
        {
            ShootForward();
            animator.SetBool("isShootingForward", true);
            fire1Pressed = fire2Pressed = false;
        }
        else if (fire1Pressed && !fire2Pressed && bufferOver)
        {
            ShootLeft();
            animator.SetBool("isShootingLeft", true);
            fire1Pressed = false;
        }
        else if (fire2Pressed && !fire1Pressed && bufferOver)
        {
            ShootRight();
            animator.SetBool("isShootingRight", true);
            fire2Pressed = false;
        }
        else
        {
            animator.SetBool("isShootingForward", false);
            animator.SetBool("isShootingRight", false);
            animator.SetBool("isShootingLeft", false);
        }



    }

    void ShootForward()
    {
        for (int i = 0; i < forwardFirepoints.Length; i++)
        {
            GameObject bullet = ObjectPooler.sharedInstance.GetBullet();
            if (bullet != null)
            {
                bullet.SetActive(true);
                bullet.transform.position = forwardFirepoints[i].position;
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.AddForce(forwardFirepoints[i].up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }

    void ShootLeft()
    {
        for (int i = 0; i < leftFirepoints.Length; i++)
        {
            GameObject bullet = ObjectPooler.sharedInstance.GetDiagonalBullet();
            if (i == 0 && bullet != null)
            {
                FireBullet(bullet, leftFirepoints[i]);
            }
            else if (i == 1 && bullet != null)
            {
                FireBullet(bullet, leftFirepoints[i]);
            }

        }
    }


    void ShootRight()
    {
        for (int i = 0; i < rightFirepoints.Length; i++)
        {
            GameObject bullet = ObjectPooler.sharedInstance.GetDiagonalBullet();
            if (i == 0 && bullet != null)
            {
                FireBullet(bullet, rightFirepoints[i]);
            }
            else if (i == 1 && bullet != null)
            {
                FireBullet(bullet, rightFirepoints[i]);
            }

        }
    }

    void FireBullet(GameObject bullet, Transform firepoint)
    {
        bullet.SetActive(true);
        bullet.transform.rotation = Quaternion.Euler(0, 0, 45);
        bullet.transform.position = firepoint.position;

        bullet.transform.rotation *= firepoint.rotation;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.zero;
        bulletRb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }


}

