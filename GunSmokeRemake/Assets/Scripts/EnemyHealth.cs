using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;
    private Animator animator;
    private EnemyShooting movementScript;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponentInChildren<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        animator = GetComponentInChildren<Animator>();
        movementScript = GetComponentInChildren<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
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
        animator.SetTrigger("Die");

        EnemyMovement movementScript = GetComponent<EnemyMovement>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
        EnemyShooting shootingScript = GetComponent<EnemyShooting>();
        if (shootingScript != null)
        {
            shootingScript.enabled = false;
        }
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 2);
    }

    // reseting material to default
    private void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
