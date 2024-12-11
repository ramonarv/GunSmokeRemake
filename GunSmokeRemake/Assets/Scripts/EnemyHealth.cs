using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;
    private Animator animator;
    private EnemyShooting movementScript;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
        if (currentHealth <= 0)
        {
            Die();
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
}
