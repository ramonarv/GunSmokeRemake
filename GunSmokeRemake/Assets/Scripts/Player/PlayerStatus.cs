using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpawnManager spawnManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    public void Death()
    {
        animator.SetTrigger("Die");
        playerMovement.StopMovement();
        playerMovement.enabled = false;
        GetComponent<PlayerShooting>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        FindObjectOfType<LevelScroller>().enabled = false;
        spawnManager.StopSpawning();
        spawnManager.DestroyAllEnemies();
        GameManager.instance.EndGame();
    }
}
