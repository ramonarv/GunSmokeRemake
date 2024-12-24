using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemyMovement : MonoBehaviour
{
    private float minMoveDistance = 5f;
    private float maxMoveDistance = 8f;
    private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // randomizing the moving distance for this enemy
        float moveDistance = Random.Range(minMoveDistance, maxMoveDistance);

        startPosition = transform.position;
        endPosition = startPosition - new Vector2(0, moveDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, endPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            // checking if the end position has been reached
            if (Vector2.Distance(rb.position, endPosition) <= 0.01f)
            {
                isMoving = false;
            }
        }
    }
}
