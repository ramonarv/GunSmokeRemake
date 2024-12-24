using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] int maxHealth = 15;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject[] powerUps;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;

    }


    public void TakeDamage(int amount)
    {
        if (gameObject == null) return;

        currentHealth -= amount;
        sr.material = matWhite;

        if (currentHealth <= 0)
        {
            sr.material = matDefault;
            Break();
        }
        else
        {
            Invoke("ResetMaterial", 0.05f);
        }

    }

    private void Break()
    {
        currentHealth = maxHealth;
        GeneratePickup();
        gameObject.SetActive(false);
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void GeneratePickup()
    {
        GameObject pickup = powerUps[Random.Range(0, powerUps.Length)];
        Instantiate(pickup, transform.position, transform.rotation);
    }
}
