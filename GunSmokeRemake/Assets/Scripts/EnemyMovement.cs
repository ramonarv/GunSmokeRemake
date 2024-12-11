using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float radius;
    private Rigidbody2D rb;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Vector2.Distance(transform.position, target.position) > radius)
        {
            rb.velocity = direction * speed;
        }

        // if close enough to the player's radius, start orbiting around the player
        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            rb.velocity = transform.up * speed;
        }

        rb.rotation = angle;
        // chaning enemy animation based on current direction
        UpdateAnimation(direction);
    }

    // for changing enemy animation based on direction
    void UpdateAnimation(Vector2 direction)
    {
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingDown", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalkingRight", false);

        // determining dominant direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // horizontal direction
            if (direction.x > 0)
            {
                animator.SetBool("isWalkingRight", true);
            }
            else
            {
                animator.SetBool("isWalkingLeft", true);
            }
        }
        else
        {
            //vertical direction
            if (direction.y > 0)
            {
                animator.SetBool("isWalkingUp", true);
            }
            else
            {
                animator.SetBool("isWalkingDown", true);
            }
        }
    }
}
