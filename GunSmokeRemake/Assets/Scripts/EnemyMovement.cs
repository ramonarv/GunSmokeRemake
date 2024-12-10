using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float radius;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            rb.velocity = transform.up * speed;
        }

        rb.rotation = angle;
    }
}
