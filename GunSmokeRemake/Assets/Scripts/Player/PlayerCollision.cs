using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("ShotgunEnemy"))
        {
            PlayerStatus.instance.Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            PlayerStatus.instance.Death();
        }

        if (collision.gameObject.CompareTag("ScoreUp"))
        {
            ScoreManager.instance.AddPoint(1000);
        }

        if (collision.gameObject.CompareTag("DamageUp"))
        {
            PlayerStatus.instance.playerDamage += 1;
        }

        if (collision.gameObject.CompareTag("SpeedUp"))
        {
            PlayerStatus.instance.playerSpeed += 1;
        }
    }

}
