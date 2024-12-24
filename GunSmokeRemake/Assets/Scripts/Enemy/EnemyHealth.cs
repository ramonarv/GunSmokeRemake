using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    private EnemyMovement movementScript;
    private EnemyShooting shootingScript;
    private bool isDead = false;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    [SerializeField] GameObject corpsePrefab;
    [SerializeField] GameObject[] powerUps;

    private SpawnManager spawnManager;
    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponentInChildren<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        movementScript = GetComponentInChildren<EnemyMovement>();
        shootingScript = GetComponentInChildren<EnemyShooting>();

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

        ScoreManager.instance.AddPoint(100);

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

    // reseting material to default
    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void GeneratePickup()
    {
        int roll = Random.Range(0, 11);
        Debug.Log("Roll is: " + roll);
        if (roll == 10)
        {
            GameObject pickup = powerUps[Random.Range(0, powerUps.Length)];
            Debug.Log("Generating pickup: " + pickup);
            Instantiate(pickup, transform.position, Quaternion.identity);
        }
    }

}
