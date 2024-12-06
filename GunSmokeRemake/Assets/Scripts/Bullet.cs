using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float topBound = 10;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameObject.SetActive(false);
    }
}
