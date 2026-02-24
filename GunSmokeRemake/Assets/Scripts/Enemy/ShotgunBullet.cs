using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float force = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = -transform.up;
        rb.linearVelocity = direction * force;
    }

}
