using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Vector2.Distance(transform.position, target.position) > radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        if (Vector2.Distance(transform.position, target.position) <= radius)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }
}
