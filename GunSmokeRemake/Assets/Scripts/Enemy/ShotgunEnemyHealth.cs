using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 8;
    [SerializeField] int currentHealth;
    private ShotgunEnemyMovement movementScript;
    private ShotgunEnemyShooting shootingScript;
    private bool isDead = false;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    [SerializeField] GameObject corpsePrefab;
    [SerializeField] GameObject[] powerUps;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        movementScript = GetComponent<ShotgunEnemyMovement>();
        shootingScript = GetComponent<ShotgunEnemyShooting>();

        spawnManager = FindObjectOfType<SpawnManager>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        sr.material = matWhite;
        if (currentHealth <= 0)
        {
            sr.material = matDefault;
            Die();
        }
        else
        {
            //if enemy doesn't die, then reset material
            Invoke("ResetMaterial", 0.1f);
        }
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void GeneratePickup()
    {
        int roll = Random.Range(0, 6);
        if (roll == 5)
        {
            GameObject pickup = powerUps[Random.Range(0, powerUps.Length)];
            Instantiate(pickup, transform.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        GeneratePickup();
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());

        // instantiating a separate corpse object to scroll along the level

        GameObject corpse = null;
        corpse = Instantiate(corpsePrefab, transform.position, Quaternion.identity);

        ScoreManager.instance.AddPoint(400);

        if (sr != null)
        {
            sr.enabled = false;
        }
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
        if (shootingScript != null)
        {
            shootingScript.enabled = false;
        }

        // telling spawnmanager that this enemy doesn't exist anymore
        spawnManager.enemyCount.Remove(gameObject);

        if (corpse != null)
        {
            Destroy(corpse, 2f);
        }
        Destroy(gameObject, 2f);
    }

}
