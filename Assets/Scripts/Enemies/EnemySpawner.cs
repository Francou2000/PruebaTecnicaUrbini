using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;

    public float difficultyIncreaseRate = 0.01f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
            return;

        int index = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
        float difficultyMultiplier = 1f + (Time.time * difficultyIncreaseRate);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ApplyDifficulty(difficultyMultiplier);
        }
    }
}

