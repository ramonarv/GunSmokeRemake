using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] int moveSpeed;

    // keeping player within bounds
    private float verticalBound = 3.5f;
    private float horizontalBound = 4.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveSpeed = PlayerStatus.instance.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -horizontalBound)
        {  transform.position = new Vector2(-horizontalBound, transform.position.y);}

        if (transform.position.x > horizontalBound)
        {  transform.position = new Vector2(horizontalBound, transform.position.y);}

        if (transform.position.y < -verticalBound)
        {  transform.position = new Vector2(transform.position.x, -verticalBound);}

        if (transform.position.y > verticalBound)
        {  transform.position = new Vector2(transform.position.x, verticalBound);}

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.linearVelocity = moveInput * moveSpeed;

        moveSpeed = PlayerStatus.instance.playerSpeed;
    }

    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
