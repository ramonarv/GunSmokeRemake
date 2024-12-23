using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private float scrollSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatus.instance.isPlayerDead)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * Time.deltaTime * scrollSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
