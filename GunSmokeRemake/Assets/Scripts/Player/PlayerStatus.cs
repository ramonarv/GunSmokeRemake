using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool isPlayerDead = false;

    public int playerSpeed = 5;
    public int playerDamage = 1;

    private Animator animator;
    private PlayerMovement playerMovement;
    private SpawnManager spawnManager;

    public static PlayerStatus instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }

        isPlayerDead = false;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Update()
    {
        if (playerDamage > 4)
        {
            playerDamage = 4;
        }

        if (playerSpeed > 8)
        {
            playerSpeed = 8;
        }
    }

    public void Death()
    {
        isPlayerDead = true;
        animator.SetTrigger("Die");
        GameManager.instance.playerLives -= 1;

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
