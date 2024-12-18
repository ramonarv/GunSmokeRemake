using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float topBound = 5f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth;
            if (collision.gameObject.TryGetComponent<EnemyHealth>(out enemyHealth))
            {
                enemyHealth.TakeDamage(1);
            }
            gameObject.SetActive(false);
        }
    }
}
