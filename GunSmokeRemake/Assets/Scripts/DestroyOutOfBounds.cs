using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 10.0f;
    private float lowerBound = -7.0f;
    private float sideBound = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound || transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound || transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }

    }
}
