using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooting : MonoBehaviour
{
    private float bulletForce = 20f;
    public GameObject bulletForwardPrefab;
    public GameObject bulletLeftPrefab;
    public GameObject bulletRightPrefab;
    private Animator animator;

    public Transform forwardPoint1, forwardPoint2;
    public Transform leftPoint1, leftPoint2;
    public Transform rightPoint1, rightPoint2;

    Transform[] forwardFirepoints;
    Transform[] leftFirepoints;
    Transform[] rightFirepoints;

    private bool fire1Pressed = false;
    private bool fire2Pressed = false;
    private float fire1LastTime;
    private float fire2LastTime;
    private float fireBufferTime = 0.2f;
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
            GameObject bullet = Instantiate(bulletForwardPrefab, forwardFirepoints[i].position, forwardFirepoints[i].rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(forwardFirepoints[i].up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootLeft()
    {
        for (int i = 0; i < leftFirepoints.Length; i++)
        {
            Quaternion rotation = Rotate(60, rightFirepoints[i].rotation);
            GameObject bullet = Instantiate(bulletLeftPrefab, leftFirepoints[i].position, leftFirepoints[i].rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(rotation * Vector2.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootRight()
    {

        for (int i = 0; i < rightFirepoints.Length; i++)
        {
            Quaternion rotation = Rotate(-60, rightFirepoints[i].rotation);
            GameObject bullet = Instantiate(bulletRightPrefab, rightFirepoints[i].position, rightFirepoints[i].rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(rotation * Vector2.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    Quaternion Rotate(float angle, Quaternion y)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle) * y;
        return rotation;
    }

}

