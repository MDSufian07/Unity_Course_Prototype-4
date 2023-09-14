using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnPosRange = 9.0f;
    private int waveNum = 1;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNum);
        Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        // Find all enemy objects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Check if there are no enemies left
        if (enemies.Length == 0)
        {
            waveNum++;
            SpawnEnemyWave(waveNum);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnPosRange, spawnPosRange);
        float spawnPosZ = Random.Range(-spawnPosRange, spawnPosRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }
}
