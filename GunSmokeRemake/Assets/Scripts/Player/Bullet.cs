using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float topBound = 5f;
    private int damage;
    // Update is called once per frame
    void Update()
    {
        damage = PlayerStatus.instance.playerDamage;
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
                enemyHealth.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("ShotgunEnemy"))
        {
            ShotgunEnemyHealth enemyHealth;
            if (collision.gameObject.TryGetComponent<ShotgunEnemyHealth>(out enemyHealth))
            {
                enemyHealth.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Barrel"))
        {
            Barrel barrel;
            if (collision.gameObject.TryGetComponent<Barrel>(out barrel))
            {
                barrel.TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }
}
