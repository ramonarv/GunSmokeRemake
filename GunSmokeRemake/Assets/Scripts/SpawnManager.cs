using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    private float startDelay = 2.0f;
    private float enemyInterval = 2.0f;
    private float spawnRangeX = 4.5f;
    private float spawnPosY = 8.0f;

    public List<GameObject> enemyCount = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemyInterval);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount.RemoveAll(enemy => enemy == null);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject newEnemy = Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

        enemyCount.Add(newEnemy);
        Debug.Log("Enemies on screen: " + enemyCount.Count);
    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in enemyCount)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        enemyCount.Clear();
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}
